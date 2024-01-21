#include <iostream>
#include <windows.h>
#include <iphlpapi.h>
#include <winsock2.h>

#pragma comment(lib, "iphlpapi.lib")

int main() {
    DWORD dwSize = 0;
    DWORD dwRetVal = 0;

    // Get required buffer size
    dwRetVal = GetAdaptersInfo(NULL, &dwSize);
    if (dwRetVal != ERROR_BUFFER_OVERFLOW) {
        std::cerr << "GetAdaptersInfo failed" << std::endl;
        return 1;
    }

    PIP_ADAPTER_INFO pAdapterInfo = (PIP_ADAPTER_INFO)malloc(dwSize);
    if (pAdapterInfo == NULL) {
        std::cerr << "Error allocating memory needed to call GetAdaptersInfo" << std::endl;
        return 1;
    }

    // Get adapter info
    if ((dwRetVal = GetAdaptersInfo(pAdapterInfo, &dwSize)) != NO_ERROR) {
        std::cerr << "GetAdaptersInfo failed" << std::endl;
        free(pAdapterInfo);
        return 1;
    }

    PIP_ADAPTER_INFO pAdapter = pAdapterInfo;
    bool isConnected = false;

    while (pAdapter) {
        if (pAdapter->Type == MIB_IF_TYPE_ETHERNET && pAdapter->OperStatus == IF_OPER_STATUS_OPERATIONAL) {
            isConnected = true;
            break;
        }
        pAdapter = pAdapter->Next;
    }

    if (isConnected) {
        std::cout << "LANケーブルが接続されています。" << std::endl;
    } else {
        std::cout << "LANケーブルが接続されていません。" << std::endl;
    }

    free(pAdapterInfo);
    return 0;
}
