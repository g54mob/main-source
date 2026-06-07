using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Workshop
{
	[Serializable]
	public class WorkshopItemResult
	{
		public bool IsDownloaded { get; set; }

		public ulong NumberOfDownloads { get; set; }

		public bool CanBeEdited { get; set; }

		public PublishedFileId_t FileId { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public ulong OwnerId { get; set; }

		public uint UpVotes { get; set; }

		public uint DownVotes { get; set; }

		public float Score { get; set; }

		public Texture2D PreviewImage { get; set; }

		public System.Version Version { get; set; }

		public List<string> Tags { get; set; }
	}
}
