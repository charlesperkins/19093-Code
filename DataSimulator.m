%example/sample data
disp('Example data maker for tABI STUFF')
disp('please enter the dimensions of the array to display')

width=input('Width(pixels(data points)): ');
height=input('Height(pixels(data points)): ');
objectSize=input('"Size" of the object of interest(pixels(data points)): ');
locationx=input('Location of object of interest(x): ');
locationy=input('Location of object of interest(y): ');
noise=input('What is the noise level(%): ');
signalLevel=input('What is the signal Level(%): ');

%Making "object"

block=logspace(log10(noise/100),log10(signalLevel/100),objectSize/2);
block=[flip(1-block),1-block];
thing=ones(objectSize,objectSize);
thing=thing.*block;
thing=block(:).*thing;
subplot(2,2,1);
colormap('hot');
imagesc(thing);
colorbar;

%embedding "Graph" in the dataset
signal=ones(height,width).*(noise/100)^2./2;
signal(locationy:locationy+objectSize-1,locationx:locationx+objectSize-1)=thing;
subplot(2,2,2);
colormap('hot');
imagesc(signal);
colorbar;

%adding noise
noiseMatrix=rand(height,width).*noise/100;
noisySignal=noiseMatrix.*signal;
subplot(2,2,[3,4]);
colormap('hot');
imagesc(noisySignal);
colorbar;

fileYes=input('Write to File(y/n)?','s');
if lower(fileYes)=='y'
    filename=input('Filename: ','s');
    filepath=strcat('C:\temp\498\',filename,'.csv');
    csvwrite(filepath,noisySignal,1,0);
    type(filepath);
%     fileID=fopen(filepath,'w');
% %     fprintf(fileID,;%1.4f'Pre-Noise');
% %     fprintf(fileID,signal);
% %     fprintf(fileID,'Post-Noise');
%     fprintf(fileID,'%1.5f ',noisySignal);
%     fclose(fileID);
    
end

disp('                                                                    ')
W = input('Rerun program with completely new values (Y/N) ? ','s');
if(W == 'y' || W == 'Y')
    DataSimulator;
else
    disp('                                                                ')
    disp('End of the Program!');
end


    
