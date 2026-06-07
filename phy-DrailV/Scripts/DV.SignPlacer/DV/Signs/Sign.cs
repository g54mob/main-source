using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Signs
{
	public class Sign
	{
		private const string SIGN_CONFIG_NAME = "[sign_prefabs_config]";

		private static SignPrefabsConfig _config;

		internal readonly List<SignParameters> signParameters = new List<SignParameters>();

		private readonly bool old;

		public static SignPrefabsConfig Config
		{
			get
			{
				if (_config == null)
				{
					_config = Resources.Load<SignPrefabsConfig>("[sign_prefabs_config]");
				}
				return _config;
			}
		}

		public Sign(bool old)
		{
			this.old = old;
		}

		public GameObject Make()
		{
			if (Config == null)
			{
				Debug.LogError("Sign got null SignPrefabsConfig");
				return null;
			}
			string text = Config.Validate();
			if (!string.IsNullOrEmpty(text))
			{
				Debug.LogError("Sign config has errors: " + text);
				return null;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(Config.emptyPoleGenerator.gameObject);
			SignGenerator component = gameObject.GetComponent<SignGenerator>();
			component.data.signParameters = signParameters.ToArray();
			component.GenerateSign();
			return gameObject;
		}

		public Sign SpeedLimit(float limit, bool yellow = false)
		{
			limit = Mathf.Floor(limit);
			SignType type = ((!old) ? (yellow ? SignType.SpeedLimitYellow : SignType.SpeedLimit) : ((!yellow) ? SignType.SpeedLimitOld : SignType.SpeedLimitYellowOld));
			BaseSign baseSign = Config.GetBaseSign(type);
			SignParameters item = new SignParameters
			{
				type = type,
				signText = limit.ToString(),
				sign = baseSign
			};
			signParameters.Add(item);
			return this;
		}

		public Sign Grade(Grade grade, float gradeAngle)
		{
			SignType type;
			if (old)
			{
				int num;
				switch (grade)
				{
				default:
					num = 5;
					break;
				case DV.Signs.Grade.Flat:
					num = 7;
					break;
				case DV.Signs.Grade.Decline:
					num = 9;
					break;
				}
				type = (SignType)num;
			}
			else
			{
				int num2;
				switch (grade)
				{
				default:
					num2 = 4;
					break;
				case DV.Signs.Grade.Flat:
					num2 = 6;
					break;
				case DV.Signs.Grade.Decline:
					num2 = 8;
					break;
				}
				type = (SignType)num2;
			}
			BaseSign baseSign = Config.GetBaseSign(type);
			string text = "+";
			if (grade == DV.Signs.Grade.Decline)
			{
				text = "-";
			}
			SignParameters item = new SignParameters
			{
				type = type,
				signText = text + Math.Round(100f * gradeAngle, 1),
				sign = baseSign
			};
			signParameters.Add(item);
			return this;
		}

		public Sign Arrow(bool left)
		{
			SignType type = (left ? SignType.ArrowLeft : SignType.ArrowRight);
			BaseSign baseSign = Config.GetBaseSign(type);
			SignParameters item = new SignParameters
			{
				type = type,
				sign = baseSign
			};
			signParameters.Add(item);
			return this;
		}

		public Sign UpcomingSpeedUp()
		{
			SignType type = (old ? SignType.UpcomingSpeedUpOld : SignType.UpcomingSpeedUp);
			BaseSign baseSign = Config.GetBaseSign(type);
			SignParameters item = new SignParameters
			{
				type = type,
				sign = baseSign
			};
			signParameters.Add(item);
			return this;
		}

		public Sign UpcomingSpeedDown()
		{
			SignType type = (old ? SignType.UpcomingSpeedDownOld : SignType.UpcomingSpeedDown);
			BaseSign baseSign = Config.GetBaseSign(type);
			SignParameters item = new SignParameters
			{
				type = type,
				sign = baseSign
			};
			signParameters.Add(item);
			return this;
		}

		public Sign UpcomingJunction()
		{
			SignType type = (old ? SignType.UpcomingJunctionOld : SignType.UpcomingJunction);
			BaseSign baseSign = Config.GetBaseSign(type);
			SignParameters item = new SignParameters
			{
				type = type,
				sign = baseSign
			};
			signParameters.Add(item);
			return this;
		}

		public Sign UpcomingJunctionDistance(float distance)
		{
			SignType type = SignType.RectWhite;
			BaseSign baseSign = Config.GetBaseSign(type);
			SignParameters item = new SignParameters
			{
				type = type,
				signText = Math.Round(distance * 0.001f, 1).ToString(),
				sign = baseSign
			};
			signParameters.Add(item);
			return this;
		}

		public Sign UpcomingTrackEnd()
		{
			SignType type = (old ? SignType.UpcomingTrackEndOld : SignType.UpcomingTrackEnd);
			BaseSign baseSign = Config.GetBaseSign(type);
			SignParameters item = new SignParameters
			{
				type = type,
				sign = baseSign
			};
			signParameters.Add(item);
			return this;
		}
	}
}
