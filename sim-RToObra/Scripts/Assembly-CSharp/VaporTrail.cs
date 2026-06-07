using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VaporTrail : MonoBehaviour
{
	public class Link
	{
		public float loc0;

		public float loc1;

		public GameObject go;

		public Transform transform
		{
			get
			{
				return go.transform;
			}
		}

		public Link(Transform parent, Mesh mesh, Material material)
		{
			go = new GameObject("Link");
			go.transform.SetParent(parent, false);
			go.SetActive(false);
			MeshFilter meshFilter = go.AddComponent<MeshFilter>();
			meshFilter.sharedMesh = mesh;
			MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
			meshRenderer.receiveShadows = false;
			meshRenderer.lightProbeUsage = LightProbeUsage.Off;
			meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
			meshRenderer.sharedMaterial = material;
		}

		public void Configure(Vector3 p0, Vector3 p1, float loc0_, float loc1_, float bulge0, float bulge1)
		{
			loc0 = loc0_;
			loc1 = loc1_;
			go.transform.localPosition = p0;
			go.transform.localRotation = Quaternion.LookRotation(p1 - p0, UnityEngine.Random.onUnitSphere);
			go.transform.localScale = new Vector3(1f, 1f, (p0 - p1).magnitude);
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetVector("_VaporLinkInfo", new Vector4(loc0, loc1, bulge0, bulge1));
			MeshRenderer component = go.GetComponent<MeshRenderer>();
			component.SetPropertyBlock(materialPropertyBlock);
		}

		public void UpdateActive(float headLoc, float tailLoc)
		{
			go.SetActive(loc0 < headLoc && loc1 > tailLoc);
		}
	}

	[Serializable]
	public class BulgePinchVal
	{
		public float pinch;

		public float bulge;
	}

	public Mesh linkMesh;

	public Material linkMaterial;

	public AudioClip startAudioClip;

	public AudioClip[] flightAudioClips;

	[Space]
	public int numLinksPerSegment = 2;

	public int numParticlesPerLink = 20;

	public float wavePeriod = 1f;

	public float speed = 3f;

	public float spread = 10f;

	public BulgePinchVal waveAmplitude;

	public BulgePinchVal particleSize;

	public float particleBirthDeathScale = 0.5f;

	[HideInInspector]
	public VaporTrailPath path;

	private float totalLength;

	private float flightLoc;

	private float flightLocVel;

	private int flightNextAudioIndex;

	private AudioOneShot flightAudioOneShot;

	private List<Link> links = new List<Link>();

	private List<Vector3> worldPoints = new List<Vector3>();

	private List<float> bodyStopLengths;

	private const float kFlightAudioVolume = 0.5f;

	public bool inFlight { get; private set; }

	public int reachedBodyIndex
	{
		get
		{
			for (int num = bodyStopLengths.Count - 1; num >= 0; num--)
			{
				if (flightLoc > bodyStopLengths[num])
				{
					return num;
				}
			}
			return -1;
		}
	}

	public Vector3 launchTriggerPos
	{
		get
		{
			return worldPoints[1];
		}
	}

	private bool playerCanAlwaysSee
	{
		get
		{
			return path != null && flightLoc < 5f && path.name.EndsWith("butcher");
		}
	}

	public void SetPath(VaporTrailPath path_)
	{
		path = path_;
		worldPoints = new List<Vector3>(path.points);
		worldPoints.Insert(0, Vector3.zero);
		int num = worldPoints.Count * numLinksPerSegment;
		for (int i = links.Count; i < num; i++)
		{
			links.Add(new Link(base.transform, linkMesh, linkMaterial));
		}
		while (links.Count > num)
		{
			Link link = links[num - 1];
			links.Remove(link);
			UnityEngine.Object.Destroy(link.go);
		}
		inFlight = false;
	}

	public void Launch(Vector3 start)
	{
		AudioOneShot.Play(startAudioClip, false, 0.5f);
		flightAudioOneShot = AudioOneShot.Play(flightAudioClips[0], false, 0.5f);
		flightNextAudioIndex = 1;
		worldPoints[0] = start;
		totalLength = 0f;
		Vector3 zero = Vector3.zero;
		Vector3 vector = Vector3.zero;
		float num = 0f;
		float num2 = 0f;
		int num3 = -1;
		int num4 = 0;
		bodyStopLengths = new List<float>();
		List<Vector3> points = Bezier.AutoSmoothed(worldPoints);
		foreach (Vector3 item in Bezier.IterateLine(numLinksPerSegment, points))
		{
			Vector3 vector2 = base.transform.worldToLocalMatrix.MultiplyPoint(item);
			float num5 = Util.LerpScale(Mathf.Cos((float)Math.PI * 2f * totalLength / wavePeriod) + 1f, 2f, 0f, 0f, 1f) * Util.LerpScale(Mathf.Cos((float)Math.PI * 2f * totalLength / (wavePeriod / 3.33f)) + 1f, 2f, 0f, 0.8f, 1f);
			if (num3 < 0)
			{
				vector = vector2;
				num2 = num5;
			}
			else
			{
				float loc0_ = totalLength;
				num = num2;
				num2 = num5;
				zero = vector;
				vector = vector2;
				totalLength += (vector - zero).magnitude;
				Link link = links[num3];
				link.Configure(zero, vector, loc0_, totalLength, num, num2);
			}
			if (num4 < path.stops.Count && num3 / numLinksPerSegment - 1 == path.stops[num4].pointIndex)
			{
				bodyStopLengths.Add(totalLength);
				num4++;
			}
			num3++;
		}
		if (num4 < path.stops.Count && num3 / numLinksPerSegment - 1 == path.stops[num4].pointIndex)
		{
			bodyStopLengths.Add(totalLength);
			num4++;
		}
		inFlight = true;
		flightLoc = 0f;
	}

	private void Update()
	{
		if (!inFlight)
		{
			return;
		}
		if (flightLoc > 2f && flightLoc < totalLength)
		{
			if (playerCanAlwaysSee || Player.CanSee(GetLocWorldPos(flightLoc)))
			{
				flightLocVel = speed;
			}
			else
			{
				flightLocVel = Mathf.Max(0f, flightLocVel - Clock.play.deltaTime);
			}
			flightLoc = Mathf.Min(totalLength, flightLoc + Clock.play.deltaTime * flightLocVel);
		}
		else
		{
			flightLoc += Clock.play.deltaTime * speed;
		}
		if (flightNextAudioIndex < flightAudioClips.Length && flightLoc / totalLength >= (float)flightNextAudioIndex / (float)(flightAudioClips.Length - 1))
		{
			flightAudioOneShot.Stop(0.5f);
			flightAudioOneShot = AudioOneShot.Play(flightAudioClips[flightNextAudioIndex], false, 0.5f);
			flightNextAudioIndex++;
		}
		float num = flightLoc - Util.LerpScale(Mathf.Cos(Clock.play.time * 3f), -1f, 1f, 0f, 1f) * 0.5f;
		float num2 = Mathf.Max(0f, num - spread);
		Shader.SetGlobalVector("_VaporTrailInfo", new Vector4(Mathf.Lerp(num2, num, 0f), Mathf.Lerp(num2, num, 0.5f), Mathf.Lerp(num2, num, 0.75f), Mathf.Lerp(num2, num, 1f)));
		Shader.SetGlobalVector("_VaporTrailSizes", new Vector4(particleSize.pinch * particleBirthDeathScale, particleSize.pinch, particleSize.bulge * particleBirthDeathScale, particleSize.bulge));
		Shader.SetGlobalVector("_VaporTrailWaveAmp", new Vector4(waveAmplitude.pinch, waveAmplitude.bulge, 0f, 0f));
		foreach (Link link in links)
		{
			link.UpdateActive(num, num2);
		}
		if (flightLoc > totalLength + spread)
		{
			inFlight = false;
			flightAudioOneShot.Stop(3f);
			base.gameObject.SetActive(false);
		}
		if (!DebugMenu.IsOn("Show/VaporTrails"))
		{
			return;
		}
		DebugDrawer.World(delegate(DebugDrawer dd)
		{
			dd.DrawCircle(Color.magenta, GetLocWorldPos(flightLoc), 0.2f);
			for (int i = 0; i < links.Count - 1; i++)
			{
				dd.DrawLine(Color.yellow, links[i].transform.position, links[i + 1].transform.position);
			}
			foreach (Vector3 worldPoint in worldPoints)
			{
				dd.DrawCircle(Color.red, worldPoint + UnityEngine.Random.insideUnitSphere * 0.01f, 0.05f);
			}
		});
	}

	private Vector3 GetLocWorldPos(float loc)
	{
		loc = Mathf.Clamp(loc, 0f, totalLength - 0.001f);
		foreach (Link link in links)
		{
			if (loc >= link.loc0 && loc < link.loc1)
			{
				return link.transform.localToWorldMatrix.MultiplyPoint(Util.LerpScale(loc, link.loc0, link.loc1, 0f, 1f) * Vector3.forward);
			}
		}
		return Vector3.zero;
	}
}
