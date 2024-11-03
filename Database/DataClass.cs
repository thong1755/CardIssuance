using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CardIssuance.Database
{
    public class DataClass
    {
        public enum VersionPlate
        {
            Version2 = 1,
            Version3 = 2
        }

        public enum WeightVoteTemplate
        {
            A5 = 1,
            A4 = 2
        }

        public enum WeightValueStatus
        {
            Conn = 1,
            Disconn = 2,
            Err = 3
        }

        [Flags]
        public enum MastComplete
        {
            PLATE1_1 = 0x1,
            PLATE1_2 = 0x2,
            PLATE2_1 = 0x4,
            PLATE2_2 = 0x8,
            CMR1_1 = 0x10,
            CMR1_2 = 0x20,
            CMR2_1 = 0x40,
            CMR2_2 = 0x80,
            CMR3_1 = 0x100,
            CMR3_2 = 0x200,
            COMPLETEALL = PLATE1_1 | PLATE1_2 | PLATE2_1 | PLATE2_2 | CMR1_1 | CMR1_2 | CMR2_1 | CMR2_2 | CMR3_1 | CMR3_2
        }

        public struct WeightValue
        {
            public int Status;
            public string Value;
        }

        public struct CAMStatus
        {
            public string Cam1;
            public string Cam2;
            public string Cam3;
        }

        public struct ImageView
        {
            public bool Complete;
            public BitmapImage image;
        }

        public struct ImageViews
        {
            public ImageView plate1_1;
            public ImageView plate1_2;
            public ImageView plate2_1;
            public ImageView plate2_2;
            public ImageView CMR1_1;
            public ImageView CMR1_2;
            public ImageView CMR2_1;
            public ImageView CMR2_2;
            public ImageView CMR3_1;
            public ImageView CMR3_2;
        }

        public struct ComPort
        {
            public string Port;
            public string BaudRate;
            public string Parity;
            public string DataBit;
            public string Stopbit;
            public bool Opent;
            public int ScanRate;
        }

        public struct ConnWeight
        {
            public ComPort Comport;
            public string Stx;
            public string Etx;
            public int Length;
            public int IndexStart;
            public int TimeUpdate;
            public int TimeStabilize;
            public bool Busy;
            public bool Auto;
        }

        public struct Camera
        {
            public string IPAddrees;
            public string UseName;
            public string Password;
            public string Port;
            public bool Active;
            public bool SubStream;
            public string Caching;
        }

        public struct ConnCamera
        {
            public Camera CMR1;
            public Camera CMR2;
            public Camera CMR3;
        }

        public struct Modbus_IO
        {
            public byte IDDevice;
            public ushort Addr;
            public bool Active;
            public bool Status;
            public bool Logic;
        }

        public struct DeviceIO
        {
            public ComPort Comport;
            public Modbus_IO Sensor1;
            public Modbus_IO Sensor2;
            public Modbus_IO Barrier1;
            public Modbus_IO Barrier2;
            public Modbus_IO Bell;
            public bool Status;
        }

        public struct ImageProcess
        {
            public int Version;
            public string Key;
            public float Percent;
            public int DataCycle;
            public string Path;
            public float Scale;
            public string PathFileTXT;
            public int SizePrint;
        }

        public struct WeightAction
        {
            public bool AutoSearchWeightVotes;
            public bool UpdateInfomationWeightVotesPlate;
            public int ManageWeight;
        }

        public struct PlateOutput
        {
            public string PicturePath;
            public string StrPlate;
            public float Persence;
            public int PlateTop;
            public int PlateLeft;
            public int PlateWidth;
            public int PlateHeight;
            public string PlatePath;
            public bool Ret;
        }

        public struct WeightFrame
        {
            public byte id;
            public byte signindex;
            public byte sign;
            public byte stx;
            public byte etx;
            public byte lenght;
            public byte indexstart;
        }

        public struct FormWeight
        {
            public int StatusWeight;
            public int WeightVotes;
            public DateTime WeightDay;
            public string CodeWeight;
            public string NumberPlate;
            public string Customer;
            public string CustomerAddress;
            public string CustomerID;
            public string GoodsName;
            public string Driver;
            public string Weigher;
            public decimal WeightMinus;
            public decimal PercentMinus;
            public decimal UnitPrice;
            public string Note;
            public string TimeWeight1;
            public decimal Weight1;
            public string TimeWeight2;
            public decimal Weight2;
            public decimal WeightGoods;
            public decimal WeightPay;
            public decimal MoneyPayment;
            public int CountWeight;
            public int DeleteVotes;
            public int CountPrint;
            public bool WeightUpdate;
        }

        public struct DataStatiscal
        {
            public string WeightDayFrom;
            public string WeightDayTo;
            public string Table;
            public string Plate;
            public string Customer;
            public string Goods;
            public string Weigher;
            public int CountWeight;
            public decimal VotesSum;
            public decimal WeightSum;
            public decimal WeightTruckSum;
            public decimal WeightGoodsSum;
        }

        public struct DataStatiscalDay
        {
            public decimal VotesSum;
            public decimal WeightSum;
            public decimal WeightTruckSum;
            public decimal WeightGoodsSum;
            public decimal WeightFirst;
        }

        public struct QuickSearch
        {
            public string SearchDay;
            public string SearchPlate1;
            public string SearchPlate2;
            public string SearchVotes;
            public int SearchCountWeight;
        }

        public struct Customer
        {
            public string ID;
            public string Name;
            public string Address;
            public string Goods;
            public string Note;
        }

        public struct Truck
        {
            public string ID;
            public string Plate;
            public string NameCustomer;
            public string Address;
            public string Goods;
            public string Driver;
            public string Note;
        }

        public struct Goods
        {
            public string ID;
            public string Name;
            public decimal Density;
            public decimal UnitPrice;
        }

        public struct Weigher
        {
            public string ID;
            public string Name;
            public string Phone;
            public string Note;
        }

        public struct User
        {
            public string Admin;
            public string Name;
            public string Password;
        }

        public struct InfomationData
        {
            public string NameCompany;
            public string AddressCompany;
            public string PhoneCompany;
            public string Region;
            public string WeightCardTitle;
            public string ReportTitle;
            public decimal UnitPrice;
            public decimal UnitPrice2;
            public string CustomerDefault;
            public string GoodNameImportDefault;
            public string GoodNameExportDefault;
        }

        public struct Login
        {
            public string IP;
            public string User;
            public string Pass;
            public string PassDatabase;
            public bool Client;
        }

        public struct Statusbar
        {
            public string Mode;
            public string ModeStatus;
            public string User;
            public string UserName;
        }

        public struct AutoReport
        {
            public int ID;
            public string EmailHost;
            public string PassHost;
            public string Email1;
            public string Email2;
            public string Email3;
            public string Email4;
            public string Email5;
            public string Subject;
            public bool AutoSend;
            public int TypeSend;
        }

        public struct SmartPlate
        {
            public string incorrect;
            public string correct;
        }

        public struct LicenseApp
        {
            public string keyApp;
            public string keyUse;
        }
    }
}
