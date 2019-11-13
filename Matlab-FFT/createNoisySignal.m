% Specify the parameters of a signal with a sampling
% frequency of 1 kHz and a signal duraion of 1.5 seconds

Fs = 1000;      % Sampling frequency
T = 1/Fs;       % Sampling period
L = 1500;       % Length of signal
t = (0:L-1)*T;  % Time vector
% signal duration of 1.5 seconds

% Form a signal containing a 50 Hz sinusoid of
% amplitude 0.7 and a 120 Hz sinusoid of amplitude 1

S = 0.7*sin(2*pi*50*t) + sin(2*pi*120*t);

% Corrupt the signal with zero-mean white noise with a variance of 4.
X = S + 2*randn(size(t))

% Create text file to hold noisy signal, put signal array into file
fileID = fopen('noisySignal.txt', 'w');
fprintf(fileID, '%f ', X);
fclose(fileID);
