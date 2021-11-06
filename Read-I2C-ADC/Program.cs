using System;

using Iot.Device.Ads1115;

using Read_I2C_ADC;

var reader = new Reader(1, 0x48, MeasuringRange.FS0256, DataRate.SPS016);
while (true) {
    Console.WriteLine($"Reading: RAW={reader.ADS.ReadRaw()}, Voltage={reader.ADS.ReadVoltage().Millivolts}");
}