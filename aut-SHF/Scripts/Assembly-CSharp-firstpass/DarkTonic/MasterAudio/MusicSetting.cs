using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	[Serializable]
	public class MusicSetting
	{
		public string alias;

		public MasterAudio.AudioLocation audLocation;

		public AudioClip clip;

		public string songName;

		public string resourceFileName;

		public float volume;

		public float pitch;

		public bool isExpanded;

		public bool isLoop;

		public bool isChecked;

		public List<SongMetadataStringValue> metadataStringValues;

		public List<SongMetadataBoolValue> metadataBoolValues;

		public List<SongMetadataIntValue> metadataIntValues;

		public List<SongMetadataFloatValue> metadataFloatValues;

		public bool metadataExpanded;

		public MasterAudio.CustomSongStartTimeMode songStartTimeMode;

		public float customStartTime;

		public float customStartTimeMax;

		public int lastKnownTimePoint;

		public bool wasLastKnownTimePointSet;

		public int songIndex;

		public float sectionStartTime;

		public float sectionEndTime;

		public bool songStartedEventExpanded;

		public string songStartedCustomEvent;

		public bool songChangedEventExpanded;

		public string songChangedCustomEvent;

		public bool HasMetadataProperties => false;

		public int MetadataPropertyCount => 0;

		public float SongStartTime => 0f;

		public static MusicSetting Clone(MusicSetting mus, MasterAudio.Playlist aList)
		{
			return null;
		}
	}
}
