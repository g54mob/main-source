using System;
using System.Text;
using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class VersionNumber
	{
		[IgnoreMember]
		private int _major;

		[IgnoreMember]
		private int _minor;

		[IgnoreMember]
		private int _patch;

		[IgnoreMember]
		private string _preReleaseVersion = "";

		[IgnoreMember]
		private string _buildMetadata = "";

		[IgnoreMember]
		[DontSave]
		private bool _versionIsDirty = true;

		[IgnoreMember]
		[DontSave]
		private bool _fullVersionIsDirty = true;

		[IgnoreMember]
		[DontSave]
		private string _versionStringCache;

		[IgnoreMember]
		[DontSave]
		private string _fullVersionStringCache;

		[Key(0)]
		public int Major
		{
			get
			{
				return _major;
			}
			set
			{
				_major = value;
				_versionIsDirty = true;
				_fullVersionIsDirty = true;
			}
		}

		[Key(1)]
		public int Minor
		{
			get
			{
				return _minor;
			}
			set
			{
				_minor = value;
				_versionIsDirty = true;
				_fullVersionIsDirty = true;
			}
		}

		[Key(2)]
		public int Patch
		{
			get
			{
				return _patch;
			}
			set
			{
				_patch = value;
				_versionIsDirty = true;
				_fullVersionIsDirty = true;
			}
		}

		[Key(3)]
		public string PreReleaseVersion
		{
			get
			{
				return _preReleaseVersion;
			}
			set
			{
				_preReleaseVersion = value;
				_versionIsDirty = true;
				_fullVersionIsDirty = true;
			}
		}

		[Key(4)]
		public string BuildMetadata
		{
			get
			{
				return _buildMetadata;
			}
			set
			{
				_buildMetadata = value;
				_versionIsDirty = true;
				_fullVersionIsDirty = true;
			}
		}

		[IgnoreMember]
		public string VersionString
		{
			get
			{
				if (_versionIsDirty)
				{
					_versionStringCache = CreateVersionString(Major, Minor, Patch, null, null);
					_versionIsDirty = false;
				}
				return _versionStringCache;
			}
		}

		[IgnoreMember]
		public string FullVersionString
		{
			get
			{
				if (_fullVersionIsDirty)
				{
					_fullVersionStringCache = CreateVersionString(Major, Minor, Patch, PreReleaseVersion, BuildMetadata);
					_fullVersionIsDirty = false;
				}
				return _fullVersionStringCache;
			}
		}

		public override string ToString()
		{
			return FullVersionString;
		}

		public static string CreateVersionString(int major, int minor, int patch, string identifier, string buildMetadata)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(major);
			stringBuilder.Append('.');
			stringBuilder.Append(minor);
			stringBuilder.Append('.');
			stringBuilder.Append(patch);
			if (!string.IsNullOrEmpty(identifier))
			{
				stringBuilder.Append('-');
				stringBuilder.Append(identifier);
			}
			if (!string.IsNullOrEmpty(buildMetadata))
			{
				stringBuilder.Append('+');
				stringBuilder.Append(buildMetadata);
			}
			return stringBuilder.ToString();
		}

		public static bool operator <(VersionNumber lhs, VersionNumber rhs)
		{
			if (lhs.Major != rhs.Major)
			{
				return lhs.Major < rhs.Major;
			}
			if (lhs.Minor != rhs.Minor)
			{
				return lhs.Minor < rhs.Minor;
			}
			if (lhs.Patch != rhs.Patch)
			{
				return lhs.Patch < rhs.Patch;
			}
			if (lhs.PreReleaseVersion != rhs.PreReleaseVersion)
			{
				if (!string.IsNullOrEmpty(lhs.PreReleaseVersion) || string.IsNullOrEmpty(rhs.PreReleaseVersion))
				{
					if (!string.IsNullOrEmpty(lhs.PreReleaseVersion) && !string.IsNullOrEmpty(rhs.PreReleaseVersion))
					{
						return string.Compare(lhs.PreReleaseVersion, rhs.PreReleaseVersion, StringComparison.Ordinal) < 0;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		public static bool operator >(VersionNumber lhs, VersionNumber rhs)
		{
			if (!AreEqual(lhs, rhs))
			{
				return !(lhs < rhs);
			}
			return false;
		}

		public static bool AreEqual(VersionNumber lhs, VersionNumber rhs)
		{
			if (lhs == rhs)
			{
				return true;
			}
			if (lhs == null || rhs == null)
			{
				return false;
			}
			if (lhs.Major == rhs.Major && lhs.Minor == rhs.Minor && lhs.Patch == rhs.Patch)
			{
				return lhs.PreReleaseVersion == rhs.PreReleaseVersion;
			}
			return false;
		}
	}
}
