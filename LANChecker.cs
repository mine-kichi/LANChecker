using System;
using System.Linq;
using System.Net.NetworkInformation;

class Program {
    static void Main() {
        bool isCableConnected = false;

        foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces()) {
            if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet) {
                if (ni.OperationalStatus == OperationalStatus.Up) {
                    isCableConnected = true;
                    break;
                }
            }
        }

        if (isCableConnected) {
            Console.WriteLine("LANケーブルが物理的に接続されています。");
        } else {
            Console.WriteLine("LANケーブルが物理的に接続されていない、またはネットワーク接続に問題があります。");
        }
    }
}
