using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine;

public static class _0023_003DqyYdIqibhysMNyI0wDC8yBg_003D_003D
{
	private sealed class _0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D
	{
		public WebRequest _0023_003Dqc5YjIPWlt_x0JuKNjYrkZA_003D_003D;

		public Action<byte[]> _0023_003DqupJ0Pl0OI9HQUgSsMScUGw_003D_003D;

		public Action _0023_003DqPBGy8U6IpZBQqi3J8kbIdg_003D_003D;

		public _0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D(WebRequest _0023_003Dq_IBkfJ_0024vX42DTSbR7dgMog_003D_003D, Action<byte[]> _0023_003DqMMOyrco4jWFD1RZUvX0Ngg_003D_003D, Action _0023_003DqOf4N1DVch9HbJI3_0024S_0024BNFQ_003D_003D)
		{
			if (3u != 0)
			{
				_0023_003Dqc5YjIPWlt_x0JuKNjYrkZA_003D_003D = _0023_003Dq_IBkfJ_0024vX42DTSbR7dgMog_003D_003D;
			}
			if (6u != 0)
			{
				_0023_003DqupJ0Pl0OI9HQUgSsMScUGw_003D_003D = _0023_003DqMMOyrco4jWFD1RZUvX0Ngg_003D_003D;
			}
			if (0 == 0)
			{
				_0023_003DqPBGy8U6IpZBQqi3J8kbIdg_003D_003D = _0023_003DqOf4N1DVch9HbJI3_0024S_0024BNFQ_003D_003D;
			}
		}
	}

	public static readonly int _0023_003Dq9Wqeuaqqpd288DFq3F7zYw_003D_003D;

	private static Func<KeyValuePair<string, string>, string> _0023_003Dquh6ib1ba8S7ShnotgTKJ2g_003D_003D;

	static _0023_003DqyYdIqibhysMNyI0wDC8yBg_003D_003D()
	{
		if (0 == 0)
		{
			_0023_003Dq9Wqeuaqqpd288DFq3F7zYw_003D_003D = 4000;
		}
	}

	public static void _0023_003Dq_d4xOwH_0024tCWSGAuRJgKmpw_003D_003D(string _0023_003Dq7zz2AlH2Nl7DkIU_AHAx4Q_003D_003D, Action<byte[]> _0023_003DqVcuwclqGVye9MH1D_00248mBzw_003D_003D, Action _0023_003DqV1wXPSVHg0JPnr0Qt3JPRg_003D_003D)
	{
		try
		{
			WebRequest webRequest = WebRequest.Create(_0023_003Dq7zz2AlH2Nl7DkIU_AHAx4Q_003D_003D);
			WebRequest webRequest2;
			if (uint.MaxValue != 0)
			{
				webRequest2 = webRequest;
			}
			webRequest2.Method = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991430);
			webRequest2.Timeout = _0023_003Dq9Wqeuaqqpd288DFq3F7zYw_003D_003D;
			webRequest2.BeginGetResponse(_0023_003Dq2LvWg16iglze9XRb0gWF2I8TP6ul0XD75coW5NvNFTI_003D, new _0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D(webRequest2, _0023_003DqVcuwclqGVye9MH1D_00248mBzw_003D_003D, _0023_003DqV1wXPSVHg0JPnr0Qt3JPRg_003D_003D));
		}
		catch (Exception)
		{
			_0023_003DqV1wXPSVHg0JPnr0Qt3JPRg_003D_003D();
		}
	}

	public static void _0023_003Dqa57xEFe6topezo2vLdzB8g_003D_003D(string _0023_003DqyaKgIyTqBavcg8O8ORd9Sw_003D_003D, byte[] _0023_003DqpyM5XZ4IDdmnYvcwnDCRMA_003D_003D, Action<byte[]> _0023_003DqD8wIOqgrBkOkjtwH_xM2xg_003D_003D, Action _0023_003DqaDFAMt7cFblGthhjeIWLUA_003D_003D)
	{
		try
		{
			WebRequest webRequest = WebRequest.Create(_0023_003DqyaKgIyTqBavcg8O8ORd9Sw_003D_003D);
			WebRequest webRequest2;
			if (3u != 0)
			{
				webRequest2 = webRequest;
			}
			webRequest2.Method = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991444);
			webRequest2.ContentType = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991455);
			webRequest2.ContentLength = _0023_003DqpyM5XZ4IDdmnYvcwnDCRMA_003D_003D.Length;
			webRequest2.Timeout = _0023_003Dq9Wqeuaqqpd288DFq3F7zYw_003D_003D;
			Stream requestStream = webRequest2.GetRequestStream();
			Stream stream;
			if (3u != 0)
			{
				stream = requestStream;
			}
			stream.Write(_0023_003DqpyM5XZ4IDdmnYvcwnDCRMA_003D_003D, 0, _0023_003DqpyM5XZ4IDdmnYvcwnDCRMA_003D_003D.Length);
			stream.Close();
			webRequest2.BeginGetResponse(_0023_003Dq2LvWg16iglze9XRb0gWF2I8TP6ul0XD75coW5NvNFTI_003D, new _0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D(webRequest2, _0023_003DqD8wIOqgrBkOkjtwH_xM2xg_003D_003D, _0023_003DqaDFAMt7cFblGthhjeIWLUA_003D_003D));
		}
		catch (Exception)
		{
			_0023_003DqaDFAMt7cFblGthhjeIWLUA_003D_003D();
		}
	}

	public static void _0023_003Dqyie80JbGAK2xcvBfp2JKfA_003D_003D(string _0023_003Dqu4u_0024wB78TWwckk_S7BRo7A_003D_003D, Dictionary<string, string> _0023_003DqEltz0EF7nLZpxl6nXIUGsA_003D_003D, Action<byte[]> _0023_003DqN5eSBiuT_0024bWLBF5LCSqpXw_003D_003D, Action _0023_003Dq7YoxDYvOYo1x98ixjC3RLw_003D_003D)
	{
		try
		{
			string separator = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991546);
			if (_0023_003Dquh6ib1ba8S7ShnotgTKJ2g_003D_003D == null)
			{
				Func<KeyValuePair<string, string>, string> func = _0023_003DqAnlO7OUBdtWcodvdmF61h_mBTLU2vLVT1o2c1L7IEQ0_003D;
				if (true)
				{
					_0023_003Dquh6ib1ba8S7ShnotgTKJ2g_003D_003D = func;
				}
			}
			string text = string.Join(separator, _0023_003DqEltz0EF7nLZpxl6nXIUGsA_003D_003D.Select(_0023_003Dquh6ib1ba8S7ShnotgTKJ2g_003D_003D).ToArray());
			string text2;
			if (5u != 0)
			{
				text2 = text;
			}
			WebRequest webRequest = WebRequest.Create(_0023_003Dqu4u_0024wB78TWwckk_S7BRo7A_003D_003D);
			WebRequest webRequest2;
			if (5u != 0)
			{
				webRequest2 = webRequest;
			}
			webRequest2.Method = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991444);
			webRequest2.ContentType = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991490);
			webRequest2.ContentLength = text2.Length;
			webRequest2.Timeout = _0023_003Dq9Wqeuaqqpd288DFq3F7zYw_003D_003D;
			StreamWriter streamWriter = new StreamWriter(webRequest2.GetRequestStream());
			try
			{
				streamWriter.Write(text2);
			}
			finally
			{
				((IDisposable)streamWriter).Dispose();
			}
			webRequest2.BeginGetResponse(_0023_003Dq2LvWg16iglze9XRb0gWF2I8TP6ul0XD75coW5NvNFTI_003D, new _0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D(webRequest2, _0023_003DqN5eSBiuT_0024bWLBF5LCSqpXw_003D_003D, _0023_003Dq7YoxDYvOYo1x98ixjC3RLw_003D_003D));
		}
		catch (Exception)
		{
			_0023_003Dq7YoxDYvOYo1x98ixjC3RLw_003D_003D();
		}
	}

	private static void _0023_003Dq2LvWg16iglze9XRb0gWF2I8TP6ul0XD75coW5NvNFTI_003D(IAsyncResult _0023_003Dq3962YKmAREC5yc6nb7JSVQ_003D_003D)
	{
		_0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D obj = _0023_003Dq3962YKmAREC5yc6nb7JSVQ_003D_003D.AsyncState as _0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D;
		_0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D _0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D2;
		if (8u != 0)
		{
			_0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D2 = obj;
		}
		try
		{
			WebResponse webResponse = _0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D2._0023_003Dqc5YjIPWlt_x0JuKNjYrkZA_003D_003D.EndGetResponse(_0023_003Dq3962YKmAREC5yc6nb7JSVQ_003D_003D);
			WebResponse webResponse2;
			if (uint.MaxValue != 0)
			{
				webResponse2 = webResponse;
			}
			Stream responseStream = webResponse2.GetResponseStream();
			Stream stream;
			if (2u != 0)
			{
				stream = responseStream;
			}
			byte[] array = new byte[webResponse2.ContentLength];
			for (int i = 0; i < array.Length; i += stream.Read(array, i, array.Length - i))
			{
			}
			stream.Close();
			_0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D2._0023_003DqupJ0Pl0OI9HQUgSsMScUGw_003D_003D(array);
		}
		catch (Exception)
		{
			_0023_003DqHFlYnOT1Nos_veNVbugMtQ_003D_003D2._0023_003DqPBGy8U6IpZBQqi3J8kbIdg_003D_003D();
		}
	}

	private static string _0023_003DqAnlO7OUBdtWcodvdmF61h_mBTLU2vLVT1o2c1L7IEQ0_003D(KeyValuePair<string, string> _0023_003DqsR0zaqrqE1HpHVdAhIlhNQ_003D_003D)
	{
		return WWW.EscapeURL(_0023_003DqsR0zaqrqE1HpHVdAhIlhNQ_003D_003D.Key) + _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991850) + WWW.EscapeURL(_0023_003DqsR0zaqrqE1HpHVdAhIlhNQ_003D_003D.Value);
	}
}
