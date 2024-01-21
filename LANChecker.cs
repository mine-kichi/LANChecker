using System;
using System.Linq;
using System.Net.NetworkInformation;

class Program {
    static void Main() {
        bool isConnected = false;

        foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces()) {
            if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet && ni.OperationalStatus == OperationalStatus.Up) {
                isConnected = true;
                break;
            }
        }

        if (isConnected) {
            Console.WriteLine("LANケーブルが接続されています。");
        } else {
            Console.WriteLine("LANケーブルが接続されていません。");
        }
    }
}


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
