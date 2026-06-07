using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "trustPow", "launchDuration", "powerCurve", "isInit", "partName", "mainImage", "mass" })]
	public class ES3UserType_RocketMotor : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_RocketMotor()
			: base(typeof(RocketMotor))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			RocketMotor rocketMotor = (RocketMotor)obj;
			writer.WriteProperty("trustPow", rocketMotor.trustPow, ES3Type_float.Instance);
			writer.WriteProperty("launchDuration", rocketMotor.launchDuration, ES3Type_float.Instance);
			writer.WriteProperty("powerCurve", rocketMotor.powerCurve, ES3Type_AnimationCurve.Instance);
			writer.WritePrivateField("isInit", rocketMotor);
			writer.WriteProperty("partName", rocketMotor.partName, ES3Type_string.Instance);
			writer.WritePropertyByRef("mainImage", rocketMotor.mainImage);
			writer.WriteProperty("mass", rocketMotor.mass, ES3Type_float.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			RocketMotor rocketMotor = (RocketMotor)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "trustPow":
					rocketMotor.trustPow = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "launchDuration":
					rocketMotor.launchDuration = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "powerCurve":
					rocketMotor.powerCurve = reader.Read<AnimationCurve>(ES3Type_AnimationCurve.Instance);
					break;
				case "isInit":
					rocketMotor = (RocketMotor)reader.SetPrivateField("isInit", reader.Read<bool>(), rocketMotor);
					break;
				case "partName":
					rocketMotor.partName = reader.Read<string>(ES3Type_string.Instance);
					break;
				case "mainImage":
					rocketMotor.mainImage = reader.Read<Sprite>(ES3Type_Sprite.Instance);
					break;
				case "mass":
					rocketMotor.mass = reader.Read<float>(ES3Type_float.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
