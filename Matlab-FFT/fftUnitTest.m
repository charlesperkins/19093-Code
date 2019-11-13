fileID = fopen('noisySignal.txt', 'r');

S = fscanf(fileID, '%f');
fclose(fileID);

tic
Y = fft(S);
toc

% --- Using Surface Pro ---
%Elapsed time in seconds:
% 0.285788
% 0.001048
% 0.000367
% 0.000460
% 0.000664
% 0.000366

% used clear and clc, now retrying
% 0.000307
% 0.000644
% 0.000362

% closed and reopened MATLAB
% 0.028500
% 0.000436
