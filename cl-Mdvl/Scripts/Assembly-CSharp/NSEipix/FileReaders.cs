using System.Collections.Generic;
using NSEipix.FileReader;
using UnityEngine;

namespace NSEipix
{
	public static class FileReaders
	{
		private static readonly DefaultFileReader DefaultReader = new DefaultFileReader();

		private static readonly IOSFileReader IOSReader = new IOSFileReader();

		private static readonly AndroidFileReader AndroidReader = new AndroidFileReader();

		private static readonly Dictionary<RuntimePlatform, IFileReader> Readers = new Dictionary<RuntimePlatform, IFileReader>
		{
			{
				RuntimePlatform.IPhonePlayer,
				IOSReader
			},
			{
				RuntimePlatform.Android,
				AndroidReader
			}
		};

		public static IFileReader Get
		{
			get
			{
				if (Readers.ContainsKey(Application.platform))
				{
					return Readers[Application.platform];
				}
				return DefaultReader;
			}
		}
	}
}
