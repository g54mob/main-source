using UnityEngine;

public class OfficeNoiseController : MonoBehaviour
{
	private AudioSource[] _sources;

	public AnimationCurve[] Curves;

	public Transform AudioListener;

	private void Start()
	{
		_sources = GetComponentsInChildren<AudioSource>();
	}

	private void OnDestroy()
	{
		AudioManager.MasterMixer.SetFloat("UIReverbAmount", -10000f);
		AudioManager.MasterMixer.SetFloat("ReverbAmount", -10000f);
		AudioManager.MasterMixer.SetFloat("EnvReverbAmount", -10000f);
	}

	private static float AcousticToReverb(float ac)
	{
		if (ac >= 1f)
		{
			return -10000f;
		}
		return (ac * ac).MapRange(0f, 1f, 0f, -2500f);
	}

	private static float AreaToDecay(float a)
	{
		return a.MapRange(1f, 200f, 0.5f, 4f, true);
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		int num;
		Vector3 vector;
		if (CameraScript.Instance.FlyMode)
		{
			num = Mathf.FloorToInt(CameraScript.Instance.mainCam.transform.position.y / 2f);
			vector = new Vector3(CameraScript.Instance.mainCam.transform.position.x, num * 2, CameraScript.Instance.mainCam.transform.position.z);
		}
		else
		{
			num = GameSettings.Instance.ActiveFloor;
			vector = new Vector3(AudioListener.position.x, GameSettings.Instance.ActiveFloor * 2, AudioListener.position.z);
		}
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		bool flag = false;
		float num7 = 15f;
		float a = 1f;
		Vector2 pp = vector.FlattenVector3();
		bool inside;
		Room room = GameSettings.Instance.sRoomManager.RoomNear(pp, num7, num, out inside, out pp);
		float num8 = 12f;
		float num9 = 3f;
		float num10 = 2f;
		float num11 = 15f;
		float num12 = 1f;
		Room room2 = ((GUICheck.OverGUI || !HUD.Instance.BuildMode) ? null : GameSettings.Instance.sRoomManager.RoomUnderMouse());
		if (room2 != null && !room2.Outside && !room2.Outdoors && !room2.Pillar)
		{
			AudioManager.MasterMixer.SetFloat("UIReverbAmount", AcousticToReverb(room2.Acoustics));
			AudioManager.MasterMixer.SetFloat("UIReverbDecay", AreaToDecay(room2.GetAtriumArea()));
		}
		else
		{
			AudioManager.MasterMixer.SetFloat("UIReverbAmount", -10000f);
		}
		if (room != null && inside && !room.Outside && !room.Outdoors && !room.Pillar)
		{
			float value = AcousticToReverb(room.Acoustics);
			float value2 = AreaToDecay(room.GetAtriumArea());
			AudioManager.MasterMixer.SetFloat("ReverbAmount", value);
			AudioManager.MasterMixer.SetFloat("ReverbDecay", value2);
			AudioManager.MasterMixer.SetFloat("EnvReverbAmount", value);
			AudioManager.MasterMixer.SetFloat("EnvReverbDecay", value2);
		}
		else
		{
			AudioManager.MasterMixer.SetFloat("ReverbAmount", -10000f);
			AudioManager.MasterMixer.SetFloat("EnvReverbAmount", -10000f);
		}
		if (GameSettings.GameSpeed > 0f && room != null && !room.Dummy && !room.Pillar)
		{
			num12 = (vector.ReplaceY(AudioListener.position.y) - pp.ToVector3((float)room.Floor * 2f)).magnitude.MapRange(a, num7, 1f, 0f, true);
			float num13 = 0f;
			for (int i = 0; i < room.Occupants.Count; i++)
			{
				Actor actor = room.Occupants[i];
				if (actor.AItype == AI.AIType.Employee && !actor.AIScript.currentNode.Name.Equals("Loiter"))
				{
					num13 += 1f - (Mathf.Clamp((actor.ActualPosition - vector).magnitude, num9, num8) - num9) / (num8 - num9);
				}
			}
			num13 = ((num13 >= num11) ? 1f : ((!(num13 <= num10)) ? num13.MapRange(num10, num11, 0f, 1f) : 0f));
			num2 = Curves[0].Evaluate(num13);
			num3 = Curves[1].Evaluate(num13);
			num4 = Curves[2].Evaluate(num13);
			num5 = Curves[3].Evaluate(num13);
			if (room.IsOnFire || room.FurnOnFire)
			{
				num6 = 1f;
				flag = inside || room.Outdoors;
			}
			else
			{
				num6 = 0f;
				for (int j = 0; j < room.Edges.Count; j++)
				{
					WallEdge other = room.Edges[j];
					Room room3 = room.Edges[(j + 1) % room.Edges.Count].GetRoom(other);
					if (room3 != null && (room3.IsOnFire || room3.FurnOnFire))
					{
						num6 = 0.75f;
						flag = room3.Outdoors && room.Outdoors;
						break;
					}
				}
				if (num6 == 0f && room.BuildingOnFire)
				{
					num6 = 0.25f;
				}
			}
			for (int k = 0; k < 4; k++)
			{
				_sources[k].outputAudioMixerGroup = (inside ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
			}
			_sources[4].outputAudioMixerGroup = (flag ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
		}
		int num14 = 10;
		_sources[0].volume = Mathf.Lerp(_sources[0].volume, num2 * num12, Time.deltaTime * (float)num14);
		_sources[1].volume = Mathf.Lerp(_sources[1].volume, num3 * num12, Time.deltaTime * (float)num14);
		_sources[2].volume = Mathf.Lerp(_sources[2].volume, num4 * num12, Time.deltaTime * (float)num14);
		_sources[3].volume = Mathf.Lerp(_sources[3].volume, num5 * num12, Time.deltaTime * (float)num14);
		_sources[4].volume = Mathf.Lerp(_sources[4].volume, num6 * num12, Time.deltaTime * (float)num14);
	}
}
