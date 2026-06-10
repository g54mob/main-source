using System;
using System.Collections.Generic;
using System.Text;

namespace QRCoder
{
	public static class PayloadGenerator
	{
		public abstract class Payload
		{
			public virtual int Version => 0;

			public virtual QRCodeGenerator.ECCLevel EccLevel => default(QRCodeGenerator.ECCLevel);

			public virtual QRCodeGenerator.EciMode EciMode => default(QRCodeGenerator.EciMode);

			public abstract override string ToString();
		}

		public class WiFi : Payload
		{
			public enum Authentication
			{
				WEP = 0,
				WPA = 1,
				nopass = 2
			}

			private readonly string ssid;

			private readonly string password;

			private readonly string authenticationMode;

			private readonly bool isHiddenSsid;

			public WiFi(string ssid, string password, Authentication authenticationMode, bool isHiddenSSID = false, bool escapeHexStrings = true)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class Mail : Payload
		{
			public enum MailEncoding
			{
				MAILTO = 0,
				MATMSG = 1,
				SMTP = 2
			}

			private readonly string mailReceiver;

			private readonly string subject;

			private readonly string message;

			private readonly MailEncoding encoding;

			public Mail(string mailReceiver = null, string subject = null, string message = null, MailEncoding encoding = MailEncoding.MAILTO)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class SMS : Payload
		{
			public enum SMSEncoding
			{
				SMS = 0,
				SMSTO = 1,
				SMS_iOS = 2
			}

			private readonly string number;

			private readonly string subject;

			private readonly SMSEncoding encoding;

			public SMS(string number, SMSEncoding encoding = SMSEncoding.SMS)
			{
			}

			public SMS(string number, string subject, SMSEncoding encoding = SMSEncoding.SMS)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class MMS : Payload
		{
			public enum MMSEncoding
			{
				MMS = 0,
				MMSTO = 1
			}

			private readonly string number;

			private readonly string subject;

			private readonly MMSEncoding encoding;

			public MMS(string number, MMSEncoding encoding = MMSEncoding.MMS)
			{
			}

			public MMS(string number, string subject, MMSEncoding encoding = MMSEncoding.MMS)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class Geolocation : Payload
		{
			public enum GeolocationEncoding
			{
				GEO = 0,
				GoogleMaps = 1
			}

			private readonly string latitude;

			private readonly string longitude;

			private readonly GeolocationEncoding encoding;

			public Geolocation(string latitude, string longitude, GeolocationEncoding encoding = GeolocationEncoding.GEO)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class PhoneNumber : Payload
		{
			private readonly string number;

			public PhoneNumber(string number)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class SkypeCall : Payload
		{
			private readonly string skypeUsername;

			public SkypeCall(string skypeUsername)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class Url : Payload
		{
			private readonly string url;

			public Url(string url)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class WhatsAppMessage : Payload
		{
			private readonly string number;

			private readonly string message;

			public WhatsAppMessage(string number, string message)
			{
			}

			public WhatsAppMessage(string message)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class Bookmark : Payload
		{
			private readonly string url;

			private readonly string title;

			public Bookmark(string url, string title)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class ContactData : Payload
		{
			public enum ContactOutputType
			{
				MeCard = 0,
				VCard21 = 1,
				VCard3 = 2,
				VCard4 = 3
			}

			public enum AddressOrder
			{
				Default = 0,
				Reversed = 1
			}

			private readonly string firstname;

			private readonly string lastname;

			private readonly string nickname;

			private readonly string org;

			private readonly string orgTitle;

			private readonly string phone;

			private readonly string mobilePhone;

			private readonly string workPhone;

			private readonly string email;

			private readonly DateTime? birthday;

			private readonly string website;

			private readonly string street;

			private readonly string houseNumber;

			private readonly string city;

			private readonly string zipCode;

			private readonly string stateRegion;

			private readonly string country;

			private readonly string note;

			private readonly ContactOutputType outputType;

			private readonly AddressOrder addressOrder;

			public ContactData(ContactOutputType outputType, string firstname, string lastname, string nickname = null, string phone = null, string mobilePhone = null, string workPhone = null, string email = null, DateTime? birthday = null, string website = null, string street = null, string houseNumber = null, string city = null, string zipCode = null, string country = null, string note = null, string stateRegion = null, AddressOrder addressOrder = AddressOrder.Default, string org = null, string orgTitle = null)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class BitcoinLikeCryptoCurrencyAddress : Payload
		{
			public enum BitcoinLikeCryptoCurrencyType
			{
				Bitcoin = 0,
				BitcoinCash = 1,
				Litecoin = 2
			}

			private readonly BitcoinLikeCryptoCurrencyType currencyType;

			private readonly string address;

			private readonly string label;

			private readonly string message;

			private readonly double? amount;

			public BitcoinLikeCryptoCurrencyAddress(BitcoinLikeCryptoCurrencyType currencyType, string address, double? amount, string label = null, string message = null)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class BitcoinAddress : BitcoinLikeCryptoCurrencyAddress
		{
			public BitcoinAddress(string address, double? amount, string label = null, string message = null)
				: base(default(BitcoinLikeCryptoCurrencyType), null, null)
			{
			}
		}

		public class BitcoinCashAddress : BitcoinLikeCryptoCurrencyAddress
		{
			public BitcoinCashAddress(string address, double? amount, string label = null, string message = null)
				: base(default(BitcoinLikeCryptoCurrencyType), null, null)
			{
			}
		}

		public class LitecoinAddress : BitcoinLikeCryptoCurrencyAddress
		{
			public LitecoinAddress(string address, double? amount, string label = null, string message = null)
				: base(default(BitcoinLikeCryptoCurrencyType), null, null)
			{
			}
		}

		public class SwissQrCode : Payload
		{
			public class AdditionalInformation
			{
				public class SwissQrCodeAdditionalInformationException : Exception
				{
					public SwissQrCodeAdditionalInformationException()
					{
					}

					public SwissQrCodeAdditionalInformationException(string message)
					{
					}

					public SwissQrCodeAdditionalInformationException(string message, Exception inner)
					{
					}
				}

				private readonly string unstructuredMessage;

				private readonly string billInformation;

				private readonly string trailer;

				public string UnstructureMessage => null;

				public string BillInformation => null;

				public string Trailer => null;

				public AdditionalInformation(string unstructuredMessage = null, string billInformation = null)
				{
				}
			}

			public class Reference
			{
				public enum ReferenceType
				{
					QRR = 0,
					SCOR = 1,
					NON = 2
				}

				public enum ReferenceTextType
				{
					QrReference = 0,
					CreditorReferenceIso11649 = 1
				}

				public class SwissQrCodeReferenceException : Exception
				{
					public SwissQrCodeReferenceException()
					{
					}

					public SwissQrCodeReferenceException(string message)
					{
					}

					public SwissQrCodeReferenceException(string message, Exception inner)
					{
					}
				}

				private readonly ReferenceType referenceType;

				private readonly string reference;

				private readonly ReferenceTextType? referenceTextType;

				public ReferenceType RefType => default(ReferenceType);

				public string ReferenceText => null;

				public Reference(ReferenceType referenceType, string reference = null, ReferenceTextType? referenceTextType = null)
				{
				}
			}

			public class Iban
			{
				public enum IbanType
				{
					Iban = 0,
					QrIban = 1
				}

				public class SwissQrCodeIbanException : Exception
				{
					public SwissQrCodeIbanException()
					{
					}

					public SwissQrCodeIbanException(string message)
					{
					}

					public SwissQrCodeIbanException(string message, Exception inner)
					{
					}
				}

				private string iban;

				private IbanType ibanType;

				public bool IsQrIban => false;

				public Iban(string iban, IbanType ibanType)
				{
				}

				public override string ToString()
				{
					return null;
				}
			}

			public class Contact
			{
				public enum AddressType
				{
					StructuredAddress = 0,
					CombinedAddress = 1
				}

				public class SwissQrCodeContactException : Exception
				{
					public SwissQrCodeContactException()
					{
					}

					public SwissQrCodeContactException(string message)
					{
					}

					public SwissQrCodeContactException(string message, Exception inner)
					{
					}
				}

				private static readonly HashSet<string> twoLetterCodes;

				private string br;

				private string name;

				private string streetOrAddressline1;

				private string houseNumberOrAddressline2;

				private string zipCode;

				private string city;

				private string country;

				private AddressType adrType;

				[Obsolete("This constructor is deprecated. Use WithStructuredAddress instead.")]
				public Contact(string name, string zipCode, string city, string country, string street = null, string houseNumber = null)
				{
				}

				[Obsolete("This constructor is deprecated. Use WithCombinedAddress instead.")]
				public Contact(string name, string country, string addressLine1, string addressLine2)
				{
				}

				public static Contact WithStructuredAddress(string name, string zipCode, string city, string country, string street = null, string houseNumber = null)
				{
					return null;
				}

				public static Contact WithCombinedAddress(string name, string country, string addressLine1, string addressLine2)
				{
					return null;
				}

				private Contact(string name, string zipCode, string city, string country, string streetOrAddressline1, string houseNumberOrAddressline2, AddressType addressType)
				{
				}

				private static bool IsValidTwoLetterCode(string code)
				{
					return false;
				}

				private static HashSet<string> ValidTwoLetterCodes()
				{
					return null;
				}

				public override string ToString()
				{
					return null;
				}
			}

			public enum Currency
			{
				CHF = 756,
				EUR = 978
			}

			public class SwissQrCodeException : Exception
			{
				public SwissQrCodeException()
				{
				}

				public SwissQrCodeException(string message)
				{
				}

				public SwissQrCodeException(string message, Exception inner)
				{
				}
			}

			private readonly string br;

			private readonly string alternativeProcedure1;

			private readonly string alternativeProcedure2;

			private readonly Iban iban;

			private readonly decimal? amount;

			private readonly Contact creditor;

			private readonly Contact ultimateCreditor;

			private readonly Contact debitor;

			private readonly Currency currency;

			private readonly DateTime? requestedDateOfPayment;

			private readonly Reference reference;

			private readonly AdditionalInformation additionalInformation;

			public SwissQrCode(Iban iban, Currency currency, Contact creditor, Reference reference, AdditionalInformation additionalInformation = null, Contact debitor = null, decimal? amount = null, DateTime? requestedDateOfPayment = null, Contact ultimateCreditor = null, string alternativeProcedure1 = null, string alternativeProcedure2 = null)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class Girocode : Payload
		{
			public enum GirocodeVersion
			{
				Version1 = 0,
				Version2 = 1
			}

			public enum TypeOfRemittance
			{
				Structured = 0,
				Unstructured = 1
			}

			public enum GirocodeEncoding
			{
				UTF_8 = 0,
				ISO_8859_1 = 1,
				ISO_8859_2 = 2,
				ISO_8859_4 = 3,
				ISO_8859_5 = 4,
				ISO_8859_7 = 5,
				ISO_8859_10 = 6,
				ISO_8859_15 = 7
			}

			public class GirocodeException : Exception
			{
				public GirocodeException()
				{
				}

				public GirocodeException(string message)
				{
				}

				public GirocodeException(string message, Exception inner)
				{
				}
			}

			private string br;

			private readonly string iban;

			private readonly string bic;

			private readonly string name;

			private readonly string purposeOfCreditTransfer;

			private readonly string remittanceInformation;

			private readonly string messageToGirocodeUser;

			private readonly decimal amount;

			private readonly GirocodeVersion version;

			private readonly GirocodeEncoding encoding;

			private readonly TypeOfRemittance typeOfRemittance;

			public Girocode(string iban, string bic, string name, decimal amount, string remittanceInformation = "", TypeOfRemittance typeOfRemittance = TypeOfRemittance.Unstructured, string purposeOfCreditTransfer = "", string messageToGirocodeUser = "", GirocodeVersion version = GirocodeVersion.Version1, GirocodeEncoding encoding = GirocodeEncoding.ISO_8859_1)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class BezahlCode : Payload
		{
			public enum Currency
			{
				AED = 784,
				AFN = 971,
				ALL = 8,
				AMD = 51,
				ANG = 532,
				AOA = 973,
				ARS = 32,
				AUD = 36,
				AWG = 533,
				AZN = 944,
				BAM = 977,
				BBD = 52,
				BDT = 50,
				BGN = 975,
				BHD = 48,
				BIF = 108,
				BMD = 60,
				BND = 96,
				BOB = 68,
				BOV = 984,
				BRL = 986,
				BSD = 44,
				BTN = 64,
				BWP = 72,
				BYR = 974,
				BZD = 84,
				CAD = 124,
				CDF = 976,
				CHE = 947,
				CHF = 756,
				CHW = 948,
				CLF = 990,
				CLP = 152,
				CNY = 156,
				COP = 170,
				COU = 970,
				CRC = 188,
				CUC = 931,
				CUP = 192,
				CVE = 132,
				CZK = 203,
				DJF = 262,
				DKK = 208,
				DOP = 214,
				DZD = 12,
				EGP = 818,
				ERN = 232,
				ETB = 230,
				EUR = 978,
				FJD = 242,
				FKP = 238,
				GBP = 826,
				GEL = 981,
				GHS = 936,
				GIP = 292,
				GMD = 270,
				GNF = 324,
				GTQ = 320,
				GYD = 328,
				HKD = 344,
				HNL = 340,
				HRK = 191,
				HTG = 332,
				HUF = 348,
				IDR = 360,
				ILS = 376,
				INR = 356,
				IQD = 368,
				IRR = 364,
				ISK = 352,
				JMD = 388,
				JOD = 400,
				JPY = 392,
				KES = 404,
				KGS = 417,
				KHR = 116,
				KMF = 174,
				KPW = 408,
				KRW = 410,
				KWD = 414,
				KYD = 136,
				KZT = 398,
				LAK = 418,
				LBP = 422,
				LKR = 144,
				LRD = 430,
				LSL = 426,
				LYD = 434,
				MAD = 504,
				MDL = 498,
				MGA = 969,
				MKD = 807,
				MMK = 104,
				MNT = 496,
				MOP = 446,
				MRO = 478,
				MUR = 480,
				MVR = 462,
				MWK = 454,
				MXN = 484,
				MXV = 979,
				MYR = 458,
				MZN = 943,
				NAD = 516,
				NGN = 566,
				NIO = 558,
				NOK = 578,
				NPR = 524,
				NZD = 554,
				OMR = 512,
				PAB = 590,
				PEN = 604,
				PGK = 598,
				PHP = 608,
				PKR = 586,
				PLN = 985,
				PYG = 600,
				QAR = 634,
				RON = 946,
				RSD = 941,
				RUB = 643,
				RWF = 646,
				SAR = 682,
				SBD = 90,
				SCR = 690,
				SDG = 938,
				SEK = 752,
				SGD = 702,
				SHP = 654,
				SLL = 694,
				SOS = 706,
				SRD = 968,
				SSP = 728,
				STD = 678,
				SVC = 222,
				SYP = 760,
				SZL = 748,
				THB = 764,
				TJS = 972,
				TMT = 934,
				TND = 788,
				TOP = 776,
				TRY = 949,
				TTD = 780,
				TWD = 901,
				TZS = 834,
				UAH = 980,
				UGX = 800,
				USD = 840,
				USN = 997,
				UYI = 940,
				UYU = 858,
				UZS = 860,
				VEF = 937,
				VND = 704,
				VUV = 548,
				WST = 882,
				XAF = 950,
				XAG = 961,
				XAU = 959,
				XBA = 955,
				XBB = 956,
				XBC = 957,
				XBD = 958,
				XCD = 951,
				XDR = 960,
				XOF = 952,
				XPD = 964,
				XPF = 953,
				XPT = 962,
				XSU = 994,
				XTS = 963,
				XUA = 965,
				XXX = 999,
				YER = 886,
				ZAR = 710,
				ZMW = 967,
				ZWL = 932
			}

			public enum AuthorityType
			{
				[Obsolete]
				singlepayment = 0,
				singlepaymentsepa = 1,
				[Obsolete]
				singledirectdebit = 2,
				singledirectdebitsepa = 3,
				[Obsolete]
				periodicsinglepayment = 4,
				periodicsinglepaymentsepa = 5,
				contact = 6,
				contact_v2 = 7
			}

			public class BezahlCodeException : Exception
			{
				public BezahlCodeException()
				{
				}

				public BezahlCodeException(string message)
				{
				}

				public BezahlCodeException(string message, Exception inner)
				{
				}
			}

			private readonly string name;

			private readonly string iban;

			private readonly string bic;

			private readonly string account;

			private readonly string bnc;

			private readonly string sepaReference;

			private readonly string reason;

			private readonly string creditorId;

			private readonly string mandateId;

			private readonly string periodicTimeunit;

			private readonly decimal amount;

			private readonly int postingKey;

			private readonly int periodicTimeunitRotation;

			private readonly Currency currency;

			private readonly AuthorityType authority;

			private readonly DateTime executionDate;

			private readonly DateTime dateOfSignature;

			private readonly DateTime periodicFirstExecutionDate;

			private readonly DateTime periodicLastExecutionDate;

			public BezahlCode(AuthorityType authority, string name, string account = "", string bnc = "", string iban = "", string bic = "", string reason = "")
			{
			}

			public BezahlCode(AuthorityType authority, string name, string account, string bnc, decimal amount, string periodicTimeunit = "", int periodicTimeunitRotation = 0, DateTime? periodicFirstExecutionDate = null, DateTime? periodicLastExecutionDate = null, string reason = "", int postingKey = 0, Currency currency = Currency.EUR, DateTime? executionDate = null)
			{
			}

			public BezahlCode(AuthorityType authority, string name, string iban, string bic, decimal amount, string periodicTimeunit = "", int periodicTimeunitRotation = 0, DateTime? periodicFirstExecutionDate = null, DateTime? periodicLastExecutionDate = null, string creditorId = "", string mandateId = "", DateTime? dateOfSignature = null, string reason = "", string sepaReference = "", Currency currency = Currency.EUR, DateTime? executionDate = null)
			{
			}

			public BezahlCode(AuthorityType authority, string name, string account, string bnc, string iban, string bic, decimal amount, string periodicTimeunit = "", int periodicTimeunitRotation = 0, DateTime? periodicFirstExecutionDate = null, DateTime? periodicLastExecutionDate = null, string creditorId = "", string mandateId = "", DateTime? dateOfSignature = null, string reason = "", int postingKey = 0, string sepaReference = "", Currency currency = Currency.EUR, DateTime? executionDate = null, int internalMode = 0)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class CalendarEvent : Payload
		{
			public enum EventEncoding
			{
				iCalComplete = 0,
				Universal = 1
			}

			private readonly string subject;

			private readonly string description;

			private readonly string location;

			private readonly string start;

			private readonly string end;

			private readonly EventEncoding encoding;

			public CalendarEvent(string subject, string description, string location, DateTime start, DateTime end, bool allDayEvent, EventEncoding encoding = EventEncoding.Universal)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class OneTimePassword : Payload
		{
			public enum OneTimePasswordAuthType
			{
				TOTP = 0,
				HOTP = 1
			}

			public enum OneTimePasswordAuthAlgorithm
			{
				SHA1 = 0,
				SHA256 = 1,
				SHA512 = 2
			}

			[Obsolete("This enum is obsolete, use OneTimePasswordAuthAlgorithm instead", false)]
			public enum OoneTimePasswordAuthAlgorithm
			{
				SHA1 = 0,
				SHA256 = 1,
				SHA512 = 2
			}

			public OneTimePasswordAuthType Type { get; set; }

			public string Secret { get; set; }

			public OneTimePasswordAuthAlgorithm AuthAlgorithm { get; set; }

			[Obsolete("This property is obsolete, use AuthAlgorithm instead", false)]
			public OoneTimePasswordAuthAlgorithm Algorithm
			{
				get
				{
					return default(OoneTimePasswordAuthAlgorithm);
				}
				set
				{
				}
			}

			public string Issuer { get; set; }

			public string Label { get; set; }

			public int Digits { get; set; }

			public int? Counter { get; set; }

			public int? Period { get; set; }

			public override string ToString()
			{
				return null;
			}

			private string HMACToString()
			{
				return null;
			}

			private string TimeToString()
			{
				return null;
			}

			private void ProcessCommonFields(StringBuilder sb)
			{
			}
		}

		public class ShadowSocksConfig : Payload
		{
			public enum Method
			{
				Chacha20IetfPoly1305 = 0,
				Aes128Gcm = 1,
				Aes192Gcm = 2,
				Aes256Gcm = 3,
				XChacha20IetfPoly1305 = 4,
				Aes128Cfb = 5,
				Aes192Cfb = 6,
				Aes256Cfb = 7,
				Aes128Ctr = 8,
				Aes192Ctr = 9,
				Aes256Ctr = 10,
				Camellia128Cfb = 11,
				Camellia192Cfb = 12,
				Camellia256Cfb = 13,
				Chacha20Ietf = 14,
				Aes256Cb = 15,
				Aes128Ofb = 16,
				Aes192Ofb = 17,
				Aes256Ofb = 18,
				Aes128Cfb1 = 19,
				Aes192Cfb1 = 20,
				Aes256Cfb1 = 21,
				Aes128Cfb8 = 22,
				Aes192Cfb8 = 23,
				Aes256Cfb8 = 24,
				Chacha20 = 25,
				BfCfb = 26,
				Rc4Md5 = 27,
				Salsa20 = 28,
				DesCfb = 29,
				IdeaCfb = 30,
				Rc2Cfb = 31,
				Cast5Cfb = 32,
				Salsa20Ctr = 33,
				Rc4 = 34,
				SeedCfb = 35,
				Table = 36
			}

			public class ShadowSocksConfigException : Exception
			{
				public ShadowSocksConfigException()
				{
				}

				public ShadowSocksConfigException(string message)
				{
				}

				public ShadowSocksConfigException(string message, Exception inner)
				{
				}
			}

			private readonly string hostname;

			private readonly string password;

			private readonly string tag;

			private readonly string methodStr;

			private readonly string parameter;

			private readonly Method method;

			private readonly int port;

			private Dictionary<string, string> encryptionTexts;

			private Dictionary<string, string> UrlEncodeTable;

			public ShadowSocksConfig(string hostname, int port, string password, Method method, string tag = null)
			{
			}

			public ShadowSocksConfig(string hostname, int port, string password, Method method, string plugin, string pluginOption, string tag = null)
			{
			}

			private string UrlEncode(string i)
			{
				return null;
			}

			public ShadowSocksConfig(string hostname, int port, string password, Method method, Dictionary<string, string> parameters, string tag = null)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class MoneroTransaction : Payload
		{
			public class MoneroTransactionException : Exception
			{
				public MoneroTransactionException()
				{
				}

				public MoneroTransactionException(string message)
				{
				}

				public MoneroTransactionException(string message, Exception inner)
				{
				}
			}

			private readonly string address;

			private readonly string txPaymentId;

			private readonly string recipientName;

			private readonly string txDescription;

			private readonly float? txAmount;

			public MoneroTransaction(string address, float? txAmount = null, string txPaymentId = null, string recipientName = null, string txDescription = null)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class SlovenianUpnQr : Payload
		{
			private string _payerName;

			private string _payerAddress;

			private string _payerPlace;

			private string _amount;

			private string _code;

			private string _purpose;

			private string _deadLine;

			private string _recipientIban;

			private string _recipientName;

			private string _recipientAddress;

			private string _recipientPlace;

			private string _recipientSiModel;

			private string _recipientSiReference;

			public override int Version => 0;

			public override QRCodeGenerator.ECCLevel EccLevel => default(QRCodeGenerator.ECCLevel);

			public override QRCodeGenerator.EciMode EciMode => default(QRCodeGenerator.EciMode);

			private string LimitLength(string value, int maxLength)
			{
				return null;
			}

			public SlovenianUpnQr(string payerName, string payerAddress, string payerPlace, string recipientName, string recipientAddress, string recipientPlace, string recipientIban, string description, double amount, string recipientSiModel = "SI00", string recipientSiReference = "", string code = "OTHR")
			{
			}

			public SlovenianUpnQr(string payerName, string payerAddress, string payerPlace, string recipientName, string recipientAddress, string recipientPlace, string recipientIban, string description, double amount, DateTime? deadline, string recipientSiModel = "SI99", string recipientSiReference = "", string code = "OTHR")
			{
			}

			private string FormatAmount(double amount)
			{
				return null;
			}

			private int CalculateChecksum()
			{
				return 0;
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class RussiaPaymentOrder : Payload
		{
			private class MandatoryFields
			{
				public string Name;

				public string PersonalAcc;

				public string BankName;

				public string BIC;

				public string CorrespAcc;
			}

			public class OptionalFields
			{
				private string _sum;

				private string _purpose;

				private string _payeeInn;

				private string _payerInn;

				private string _drawerStatus;

				private string _kpp;

				private string _cbc;

				private string _oktmo;

				private string _paytReason;

				private string _taxPeriod;

				private string _docNo;

				private string _taxPaytKind;

				public string Sum
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public string Purpose
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public string PayeeINN
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public string PayerINN
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public string DrawerStatus
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public string KPP
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public string CBC
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public string OKTMO
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public string PaytReason
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public string TaxPeriod
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public string DocNo
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public DateTime? DocDate { get; set; }

				public string TaxPaytKind
				{
					get
					{
						return null;
					}
					set
					{
					}
				}

				public string LastName { get; set; }

				public string FirstName { get; set; }

				public string MiddleName { get; set; }

				public string PayerAddress { get; set; }

				public string PersonalAccount { get; set; }

				public string DocIdx { get; set; }

				public string PensAcc { get; set; }

				public string Contract { get; set; }

				public string PersAcc { get; set; }

				public string Flat { get; set; }

				public string Phone { get; set; }

				public string PayerIdType { get; set; }

				public string PayerIdNum { get; set; }

				public string ChildFio { get; set; }

				public DateTime? BirthDate { get; set; }

				public string PaymTerm { get; set; }

				public string PaymPeriod { get; set; }

				public string Category { get; set; }

				public string ServiceName { get; set; }

				public string CounterId { get; set; }

				public string CounterVal { get; set; }

				public string QuittId { get; set; }

				public DateTime? QuittDate { get; set; }

				public string InstNum { get; set; }

				public string ClassNum { get; set; }

				public string SpecFio { get; set; }

				public string AddAmount { get; set; }

				public string RuleId { get; set; }

				public string ExecId { get; set; }

				public string RegType { get; set; }

				public string UIN { get; set; }

				public TechCode? TechCode { get; set; }
			}

			public enum TechCode
			{
				Мобильная_связь_стационарный_телефон = 1,
				Коммунальные_услуги_ЖКХAFN = 2,
				ГИБДД_налоги_пошлины_бюджетные_платежи = 3,
				Охранные_услуги = 4,
				Услуги_оказываемые_УФМС = 5,
				ПФР = 6,
				Погашение_кредитов = 7,
				Образовательные_учреждения = 8,
				Интернет_и_ТВ = 9,
				Электронные_деньги = 10,
				Отдых_и_путешествия = 11,
				Инвестиции_и_страхование = 12,
				Спорт_и_здоровье = 13,
				Благотворительные_и_общественные_организации = 14,
				Прочие_услуги = 15
			}

			public enum CharacterSets
			{
				windows_1251 = 1,
				utf_8 = 2,
				koi8_r = 3
			}

			public class RussiaPaymentOrderException : Exception
			{
				public RussiaPaymentOrderException(string message)
				{
				}
			}

			private CharacterSets characterSet;

			private MandatoryFields mFields;

			private OptionalFields oFields;

			private string separator;

			private RussiaPaymentOrder()
			{
			}

			public RussiaPaymentOrder(string name, string personalAcc, string bankName, string BIC, string correspAcc, OptionalFields optionalFields = null, CharacterSets characterSet = CharacterSets.utf_8)
			{
			}

			public override string ToString()
			{
				return null;
			}

			public byte[] ToBytes()
			{
				return null;
			}

			private string DetermineSeparator()
			{
				return null;
			}

			private List<string> GetOptionalFieldsAsList()
			{
				return null;
			}

			private List<string> GetMandatoryFieldsAsList()
			{
				return null;
			}

			private static string ValidateInput(string input, string fieldname, string pattern, string errorText = null)
			{
				return null;
			}

			private static string ValidateInput(string input, string fieldname, string[] patterns, string errorText = null)
			{
				return null;
			}
		}

		private static bool IsValidIban(string iban)
		{
			return false;
		}

		private static bool IsValidQRIban(string iban)
		{
			return false;
		}

		private static bool IsValidBic(string bic)
		{
			return false;
		}

		private static string ConvertStringToEncoding(string message, string encoding)
		{
			return null;
		}

		private static string EscapeInput(string inp, bool simple = false)
		{
			return null;
		}

		public static bool ChecksumMod10(string digits)
		{
			return false;
		}

		private static bool isHexStyle(string inp)
		{
			return false;
		}
	}
}
