using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Crosstales;
using Crosstales.Ude;

namespace DV.Radio
{
	public class RadioPlayerThreadWrapper
	{
		private RadioStationInfo station;

		private bool useLegacy;

		private Stream ms;

		public bool playback;

		public bool hasError;

		public string errorMessage;

		public RecordInfo recordInfo;

		public RadioPlayerThreadWrapper(RadioStationInfo station, bool useLegacy, MemoryCacheStream ms)
		{
			this.station = station;
			this.useLegacy = useLegacy;
			this.ms = ms;
		}

		public Thread CreateThread()
		{
			if (useLegacy)
			{
				return new Thread((ThreadStart)delegate
				{
					ReadStreamLegacy(station.URL, ref playback, ref ms, ref hasError, ref errorMessage);
				});
			}
			return new Thread((ThreadStart)delegate
			{
				ReadStream(station, ref playback, ref ms, ref hasError, ref errorMessage, ref recordInfo);
			});
		}

		private static void ReadStream(RadioStationInfo station, ref bool playback, ref Stream ms, ref bool hasError, ref string errorMessage, ref RecordInfo recordInfo)
		{
			if (station == null || string.IsNullOrWhiteSpace(station.URL))
			{
				return;
			}
			string text = station.URL.Trim();
			if (!text.StartsWith("http://") && !text.StartsWith("https://"))
			{
				ReadStreamLegacy(text, ref playback, ref ms, ref hasError, ref errorMessage);
				return;
			}
			try
			{
				ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;
				using (CTWebClient cTWebClient = new CTWebClient(int.MaxValue))
				{
					HttpWebRequest obj = (HttpWebRequest)cTWebClient.CTGetWebRequest(text);
					obj.Headers.Clear();
					obj.Headers.Add("GET", "/ HTTP/1.1");
					obj.Headers.Add("Icy-MetaData", "1");
					obj.UserAgent = "WinampMPEG/5.09";
					using (HttpWebResponse httpWebResponse = (HttpWebResponse)obj.GetResponse())
					{
						int result = int.MaxValue;
						if (!string.IsNullOrEmpty(httpWebResponse.GetResponseHeader("icy-metaint")))
						{
							int.TryParse(httpWebResponse.GetResponseHeader("icy-metaint"), out result);
						}
						string serverNotice = (string.IsNullOrEmpty(httpWebResponse.GetResponseHeader("icy-notice2")) ? station.ServerNotice : httpWebResponse.GetResponseHeader("icy-notice2"));
						station.ServerNotice = serverNotice;
						string serverName = ((string.IsNullOrEmpty(httpWebResponse.GetResponseHeader("icy-name")) || httpWebResponse.GetResponseHeader("icy-name").Equals("-")) ? station.Name : httpWebResponse.GetResponseHeader("icy-name"));
						station.ServerName = serverName;
						string serverURL = (string.IsNullOrEmpty(httpWebResponse.GetResponseHeader("icy-url")) ? station.ServerURL : httpWebResponse.GetResponseHeader("icy-url"));
						station.ServerURL = serverURL;
						string serverGenres = (string.IsNullOrEmpty(httpWebResponse.GetResponseHeader("icy-genre")) ? station.ServerGenres : httpWebResponse.GetResponseHeader("icy-genre"));
						station.ServerGenres = serverGenres;
						string responseHeader = httpWebResponse.GetResponseHeader("icy-br");
						if (!string.IsNullOrEmpty(responseHeader) && int.TryParse(responseHeader, out var result2))
						{
							station.ServerBitrate = result2;
						}
						using (Stream stream = httpWebResponse.GetResponseStream())
						{
							if (stream == null)
							{
								return;
							}
							byte[] array = new byte[65536];
							playback = true;
							int num = 0;
							int num2 = 0;
							do
							{
								int num3;
								if ((num3 = stream.Read(array, 0, array.Length)) > 0)
								{
									int num4 = 0;
									if (result > 0 && num3 + num > result)
									{
										int num5 = 0;
										while ((num5 < num3) & playback)
										{
											if (num == result)
											{
												num = 0;
												ms.Write(array, num4, num5 - num4);
												num4 = num5;
												int num6 = Convert.ToInt32(array[num5]) * 16;
												num5++;
												num4++;
												if (num6 <= 0)
												{
													continue;
												}
												if (num6 + num4 <= num3)
												{
													byte[] array2 = new byte[num6];
													Array.Copy(array, num5, array2, 0, num6);
													if (num2 == 0)
													{
														num2 = 65001;
														CharsetDetector charsetDetector = new CharsetDetector();
														charsetDetector.Feed(array2, 0, array2.Length);
														charsetDetector.DataEnd();
														if (charsetDetector.Charset != null && charsetDetector.Confidence > 0.5f)
														{
															num2 = charsetDetector.CodePage;
														}
													}
													recordInfo = new RecordInfo(Encoding.GetEncoding(num2).GetString(array2));
													num5 += num6;
													num4 += num6;
												}
												else
												{
													num5 = num3;
													num = num3 - (num6 + num4);
												}
											}
											else
											{
												num++;
												num5++;
											}
										}
										if (num4 < num3)
										{
											ms.Write(array, num4, num3 - num4);
										}
									}
									else
									{
										num += num3;
										ms.Write(array, 0, num3);
									}
								}
								else
								{
									playback = false;
								}
							}
							while (playback);
						}
					}
				}
			}
			catch (ThreadAbortException)
			{
				playback = false;
			}
			catch (Exception)
			{
				playback = false;
				hasError = true;
				errorMessage = "Could not read URL " + text;
			}
		}

		private static void ReadStreamLegacy(string url, ref bool playback, ref Stream ms, ref bool hasError, ref string errorMessage)
		{
			if (string.IsNullOrWhiteSpace(url))
			{
				return;
			}
			url = url.Trim();
			url.StartsWith("file://");
			try
			{
				ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;
				using (CTWebClient cTWebClient = new CTWebClient(int.MaxValue))
				{
					using (WebResponse webResponse = cTWebClient.CTGetWebRequest(url.Trim()).GetResponse())
					{
						using (Stream stream = webResponse.GetResponseStream())
						{
							if (stream == null)
							{
								return;
							}
							byte[] array = new byte[65536];
							playback = true;
							do
							{
								int count;
								if ((count = stream.Read(array, 0, array.Length)) > 0 && playback)
								{
									ms.Write(array, 0, count);
								}
							}
							while (playback);
						}
					}
				}
			}
			catch (ThreadAbortException)
			{
				playback = false;
			}
			catch (Exception)
			{
				playback = false;
				hasError = true;
				errorMessage = "Could not read URL '" + url + "'";
			}
		}

		private static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			bool result = true;
			if (sslPolicyErrors != SslPolicyErrors.None)
			{
				foreach (X509ChainStatus item in chain.ChainStatus.Where((X509ChainStatus t) => t.Status != X509ChainStatusFlags.RevocationStatusUnknown))
				{
					_ = item;
					chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
					chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
					chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
					chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
					result = chain.Build((X509Certificate2)certificate);
				}
			}
			return result;
		}
	}
}
