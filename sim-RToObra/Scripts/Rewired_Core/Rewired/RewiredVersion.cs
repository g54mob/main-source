namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
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
				goto IL_0009;
			}
			if (!(obj is RewiredVersion))
			{
				return false;
			}
			RewiredVersion rewiredVersion = (RewiredVersion)obj;
			int num = 3804832;
			goto IL_000e;
			IL_0009:
			num = 3804835;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x3A0EA1)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				return this == rewiredVersion;
			}
			goto IL_0009;
		}

		public override int GetHashCode()
		{
			int num = 17;
			num = num * 29 + version1.GetHashCode();
			num = num * 29 + version2.GetHashCode();
			num = num * 29 + version3.GetHashCode();
			num = num * 29 + version4.GetHashCode();
			return num * 29 + unityVersion.GetHashCode();
		}

		public override string ToString()
		{
			object[] array = new object[7] { version1, null, null, null, null, null, null };
			string text = default(string);
			while (true)
			{
				int num = 73967734;
				while (true)
				{
					switch (num ^ 0x468A877)
					{
					case 2:
						break;
					case 4:
						text = string.Concat(array);
						if (!string.IsNullOrEmpty(unityVersion))
						{
							text = text + "." + unityVersion;
							num = 73967732;
							continue;
						}
						goto default;
					case 0:
						array[6] = version4;
						num = 73967731;
						continue;
					case 1:
						array[1] = ".";
						array[2] = version2;
						array[3] = ".";
						array[4] = version3;
						array[5] = ".";
						num = 73967735;
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
				goto IL_0013;
			}
			int num;
			if (a.version1 == b.version1 && a.version2 == b.version2 && a.version3 == b.version3)
			{
				num = 302944431;
				goto IL_0018;
			}
			goto IL_008e;
			IL_0013:
			num = 302944430;
			goto IL_0018;
			IL_0018:
			switch (num ^ 0x120E90AF)
			{
			case 2:
				break;
			case 1:
				return true;
			default:
				goto IL_006a;
			}
			goto IL_0013;
			IL_008e:
			return false;
			IL_006a:
			if (a.version4 == b.version4)
			{
				return string.Equals(a.unityVersion, b.unityVersion);
			}
			goto IL_008e;
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
				goto IL_003f;
			}
			int num;
			if (a.version2 < b.version2)
			{
				num = -1957671173;
			}
			else
			{
				if (a.version3 <= b.version3)
				{
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
				num = -1957671175;
			}
			goto IL_0044;
			IL_0044:
			switch (num ^ -1957671174)
			{
			case 0:
				break;
			case 2:
				return true;
			case 1:
				return false;
			default:
				return true;
			}
			goto IL_003f;
			IL_003f:
			num = -1957671176;
			goto IL_0044;
		}

		public static bool operator <(RewiredVersion a, RewiredVersion b)
		{
			if (a == b)
			{
				goto IL_0009;
			}
			if (a.version1 < b.version1)
			{
				return true;
			}
			int num;
			if (a.version1 > b.version1)
			{
				num = 157804057;
			}
			else
			{
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
					return true;
				}
				if (a.version3 <= b.version3)
				{
					if (a.version4 < b.version4)
					{
						return true;
					}
					if (a.version4 > b.version4)
					{
						return false;
					}
					return false;
				}
				num = 157804058;
			}
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x967E61A)
			{
			case 2:
				break;
			case 1:
				return false;
			case 3:
				return false;
			default:
				return false;
			}
			goto IL_0009;
			IL_0009:
			num = 157804059;
			goto IL_000e;
		}
	}
}
