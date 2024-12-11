using System.Runtime.InteropServices;
using Hardware.Info;

class OS
{
    public static bool IsWindows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    public static bool IsMacOS() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

    public static bool IsLinux() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    public static bool IsGpu() => GetGpuDetails();

    /// <summary>
    /// Check For
    /// </summary>
    /// <returns></returns>
    private static bool GetGpuDetails()
    {
        List<string> approved = ["NVIDIA"];

        IHardwareInfo hardwareInfo = new HardwareInfo();

        hardwareInfo.RefreshVideoControllerList();

        bool result = false;
        foreach (var h in hardwareInfo.VideoControllerList)
        {
            result = approved.Any(x => x.Contains(h.Description, StringComparison.InvariantCultureIgnoreCase));
            if (result) break;
        }

        return result;

    }
}