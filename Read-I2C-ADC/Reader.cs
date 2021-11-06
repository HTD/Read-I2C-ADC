using System;
using System.Device.I2c;
using System.Runtime.InteropServices;
using Iot.Device.Ads1115;


namespace Read_I2C_ADC;

internal class Reader {

    public int BusId { get; set; }
    public int DeviceAddress { get; set; }

    public Reader(int busId, int deviceAddress) {

        BusId = busId;
        DeviceAddress = deviceAddress;
        Device = I2cDevice.Create(new I2cConnectionSettings(BusId, DeviceAddress));
        ADS = new Ads1115(Device, InputMultiplexer.AIN0_AIN1, MeasuringRange.FS4096, DataRate.SPS128, DeviceMode.Continuous);
    }

    public unsafe short Read() {
        return ADS.ReadRaw();
        //var buffer = new byte[2];
        //fixed (void* u_buffer = buffer) {
        //    Device.Read(buffer.AsSpan());
        //    var p_buf = new IntPtr(u_buffer);
        //    return Marshal.ReadInt16(p_buf, 0);
        //}
    }

    private readonly I2cDevice Device;
    private readonly Ads1115 ADS;

}
