using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Web
{
	public class WebRequestDotNet : WebRequest
	{
		private byte[] _bytes;

		private WebClient _client;

		private string _error;

		private bool _isDone;

		private float _progress;

		private string _url;

		public override byte[] Bytes => _bytes;

		public override string Error => _error;

		public override bool IsDone => _isDone;

		public override float Progress => _progress / 100f;

		public override string Text => Encoding.Default.GetString(Bytes);

		public override string Url => _url;

		public WebRequestDotNet(string url)
		{
			ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;
			_client = new WebClient();
			_client.DownloadProgressChanged += WebClientProgressChanged;
			_client.DownloadDataCompleted += WebClientDownloadCompleted;
			_client.DownloadDataAsync(new Uri(url));
			_url = url;
		}

		public WebRequestDotNet(string url, WWWForm form, string basicAuthUsername, string basicAuthPassword)
		{
			ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;
			_client = new WebClient();
			_client.UploadProgressChanged += WebClientUploadProgressChanged;
			_client.UploadDataCompleted += WebClientUploadCompleted;
			if (!string.IsNullOrEmpty(basicAuthUsername))
			{
				string arg = Convert.ToBase64String(Encoding.ASCII.GetBytes(basicAuthUsername + ":" + basicAuthPassword));
				_client.Headers.Add(HttpRequestHeader.Authorization, $"Basic {arg}");
			}
			else
			{
				_client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
				foreach (KeyValuePair<string, string> header in form.headers)
				{
					if (header.Key == "Content-Type")
					{
						string value = header.Value;
						_client.Headers.Remove("Content-Type");
						_client.Headers["Content-Type"] = value;
					}
				}
			}
			_url = url;
			_client.UploadDataAsync(new Uri(url), form.data);
		}

		public bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			bool result = true;
			if (sslPolicyErrors != SslPolicyErrors.None)
			{
				for (int i = 0; i < chain.ChainStatus.Length; i++)
				{
					if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown)
					{
						chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
						chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
						chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
						chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
						if (!chain.Build((X509Certificate2)certificate))
						{
							result = false;
						}
					}
				}
			}
			return result;
		}

		private void WebClientDownloadCompleted(object sender, DownloadDataCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				_error = e.Error.ToString();
				Debug.Log("Web request download error: " + _error);
			}
			else
			{
				_bytes = e.Result;
			}
			_isDone = true;
		}

		private void WebClientProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			_progress += e.ProgressPercentage;
		}

		private void WebClientUploadCompleted(object sender, UploadDataCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				_error = e.Error.ToString();
				Debug.Log("Web request upload error: " + _error);
			}
			else
			{
				_bytes = e.Result;
			}
			_isDone = true;
		}

		private void WebClientUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
		{
			_progress += e.ProgressPercentage;
		}
	}
}
