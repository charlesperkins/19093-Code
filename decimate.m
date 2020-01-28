function decimate(filename,decimationRate)
    array=csvread(filename);%Read in the data
    table=array(2,:); %Make a table with just the values read in
    siz1=size(table);%generically finding the size of the table of values read in to be used in for loops etc. 
    
    decimated=zeros(1,floor(siz1(2)/decimationRate)); %Decimated array should be the size of original array divided by the decimation rate
    d=1;%placeholder variable to be used for the decimated array. 
    
    for i=1:siz1(2)%for each raw value read in
        if i<=decimationRate % for the first few values, have to use this syntax. This is not maybe necessary for matlab, but might be neccessary for C#. 
            if i==(decimationRate)%remeber to adjust array bounds for specific language
                sum=0;
                for a=1:decimationRate
                    sum=sum+table(a);
                end
                average=sum/decimationRate;
                decimated(d)=average;
                d=d+1;
            end
        elseif i> decimationRate
                if mod(i,decimationRate)==0
                    sum=0;
                    for a=1:decimationRate
                        sum=sum+table(i+1-a);
                    end
                    average=sum/decimationRate;
                    decimated(d)=average;
                    d=d+1;
                end
        end
    end
    decimate=sprintf('%f',abs(decimated));
end 