using System;
using System.Device.I2c;
using System.Runtime.InteropServices;

namespace Read_I2C_ADC;

internal class Reader {

    public int BusId { get; set; }
    public int DeviceAddress { get; set; }

    public Reader(int busId, int deviceAddress) {
        BusId = busId;
        DeviceAddress = deviceAddress;
        Device = I2cDevice.Create(new I2cConnectionSettings(BusId, DeviceAddress));
    }

    public unsafe short Read() {
        var buffer = new byte[2];
        fixed (void* u_buffer = buffer) {
            Device.Read(buffer.AsSpan());
            var p_buf = new IntPtr(u_buffer);
            return Marshal.ReadInt16(p_buf, 0);
        }
    }

    private readonly I2cDevice Device;

}
