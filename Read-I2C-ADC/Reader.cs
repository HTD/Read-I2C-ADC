using System.Device.I2c;

using Iot.Device.Ads1115;


namespace Read_I2C_ADC;

internal class Reader {

    public Ads1115 ADS { get; }

    public Reader(int busId, int deviceAddress, MeasuringRange range = MeasuringRange.FS4096, DataRate rate = DataRate.SPS016) {
        Device = I2cDevice.Create(new I2cConnectionSettings(busId, deviceAddress));
        ADS = new Ads1115(Device, InputMultiplexer.AIN0_AIN1, range, DataRate.SPS128, DeviceMode.Continuous);
    }


    private readonly I2cDevice Device;


}
