using System;

using Read_I2C_ADC;

var reader = new Reader(0, 0x48);
while (true) {
    Console.WriteLine($"Reading: {reader.Read()}");
}