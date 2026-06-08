namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal struct RewiredVersion
	{
		public int version1;

		public int version2;

		public int version3;

		public int version4;

		public string unityVersion;

		public RewiredVersion(int version1, int version2, int version3, int version4, string unityVersion)
		{
			this.version1 = version1;
			this.version2 = version2;
			this.version3 = version3;
			this.version4 = version4;
			this.unityVersion = unityVersion;
		}

		public RewiredVersion(string versionString)
		{
			if (!string.IsNullOrEmpty(versionString))
			{
				string[] array = versionString.Split('.');
				if (array.Length >= 4 && int.TryParse(array[0], out version1) && int.TryParse(array[1], out version2) && int.TryParse(array[2], out version3) && int.TryParse(array[3], out version4))
				{
					if (array.Length > 4)
					{
						unityVersion = array[4];
					}
					else
					{
						unityVersion = string.Empty;
					}
					return;
				}
			}
			version1 = 0;
			version2 = 0;
			version3 = 0;
			version4 = 0;
			unityVersion = string.Empty;
		}

		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(obj, null))
			{
				return false;
			}
			if (!(obj is RewiredVersion rewiredVersion))
			{
				return false;
			}
			return this == rewiredVersion;
		}

		public override int GetHashCode()
		{
			int num = 17;
			while (true)
			{
				int num2 = 2001111282;
				while (true)
				{
					switch (num2 ^ 0x774688F3)
					{
					case 0:
						break;
					case 1:
						goto IL_0021;
					default:
						return num * 29 + unityVersion.GetHashCode();
					}
					break;
					IL_0021:
					num = num * 29 + version1.GetHashCode();
					num = num * 29 + version2.GetHashCode();
					num = num * 29 + version3.GetHashCode();
					num = num * 29 + version4.GetHashCode();
					num2 = 2001111281;
				}
			}
		}

		public override string ToString()
		{
			object[] array = new object[7];
			string text = default(string);
			while (true)
			{
				int num = 1083438763;
				while (true)
				{
					switch (num ^ 0x4093F6A8)
					{
					case 5:
						break;
					case 4:
						array[6] = version4;
						text = string.Concat(array);
						num = 1083438767;
						continue;
					case 7:
						if (!string.IsNullOrEmpty(unityVersion))
						{
							text = text + "." + unityVersion;
							num = 1083438761;
							continue;
						}
						goto default;
					case 0:
						array[1] = ".";
						array[2] = version2;
						num = 1083438766;
						continue;
					case 2:
						array[5] = ".";
						num = 1083438764;
						continue;
					case 3:
						array[0] = version1;
						num = 1083438760;
						continue;
					case 6:
						array[3] = ".";
						array[4] = version3;
						num = 1083438762;
						continue;
					default:
						return text;
					}
					break;
				}
			}
		}

		public static bool operator ==(RewiredVersion a, RewiredVersion b)
		{
			if (object.ReferenceEquals(a, b))
			{
				return true;
			}
			if (a.version1 == b.version1)
			{
				while (true)
				{
					int num = 1664296981;
					while (true)
					{
						switch (num ^ 0x63332817)
						{
						case 0:
							break;
						case 2:
							goto IL_0043;
						default:
							goto IL_006a;
						}
						break;
						IL_006a:
						if (a.version4 != b.version4)
						{
							goto end_IL_0025;
						}
						return string.Equals(a.unityVersion, b.unityVersion);
						IL_0043:
						if (a.version2 != b.version2 || a.version3 != b.version3)
						{
							goto end_IL_0025;
						}
						num = 1664296982;
					}
					continue;
					end_IL_0025:
					break;
				}
			}
			return false;
		}

		public static bool operator !=(RewiredVersion a, RewiredVersion b)
		{
			return !(a == b);
		}

		public static bool operator >(RewiredVersion a, RewiredVersion b)
		{
			if (a == b)
			{
				return false;
			}
			if (a.version1 > b.version1)
			{
				return true;
			}
			if (a.version1 < b.version1)
			{
				return false;
			}
			if (a.version2 > b.version2)
			{
				return true;
			}
			if (a.version2 < b.version2)
			{
				return false;
			}
			if (a.version3 > b.version3)
			{
				return true;
			}
			if (a.version3 < b.version3)
			{
				return false;
			}
			if (a.version4 > b.version4)
			{
				return true;
			}
			if (a.version4 < b.version4)
			{
				return false;
			}
			return false;
		}

		public static bool operator <(RewiredVersion a, RewiredVersion b)
		{
			if (a == b)
			{
				return false;
			}
			if (a.version1 < b.version1)
			{
				return true;
			}
			if (a.version1 > b.version1)
			{
				return false;
			}
			if (a.version2 < b.version2)
			{
				return true;
			}
			if (a.version2 > b.version2)
			{
				return false;
			}
			if (a.version3 < b.version3)
			{
				goto IL_0063;
			}
			int num;
			if (a.version3 > b.version3)
			{
				num = -516608120;
			}
			else
			{
				if (a.version4 >= b.version4)
				{
					if (a.version4 > b.version4)
					{
						return false;
					}
					return false;
				}
				num = -516608117;
			}
			goto IL_0068;
			IL_0068:
			switch (num ^ -516608118)
			{
			case 0:
				break;
			case 3:
				return true;
			case 2:
				return false;
			default:
				return true;
			}
			goto IL_0063;
			IL_0063:
			num = -516608119;
			goto IL_0068;
		}
	}
}
