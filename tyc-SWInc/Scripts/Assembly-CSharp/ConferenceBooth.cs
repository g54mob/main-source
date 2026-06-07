using System;
using System.Collections.Generic;
using UnityEngine;

public class ConferenceBooth : MonoBehaviour
{
	[Serializable]
	public class BoothLight
	{
		public LightType Type;

		public float Range;

		public float Intensity;

		public float Angle;

		public Color Color;

		public Vector3 Position;

		public Vector3 Rotation;

		public BoothLight(Light l)
		{
			Type = l.type;
			Range = l.range;
			Intensity = l.intensity;
			Angle = l.spotAngle;
			Color = l.color;
			Position = l.transform.position;
			Rotation = l.transform.rotation.eulerAngles;
		}
	}

	[Serializable]
	public class Booth
	{
		public string Name;

		public Vector3 CamPos;

		public Vector3 CamRot;

		public float CamFOV;

		public float CamFar;

		public float CamNear;

		public Texture2D Color;

		public Texture2D Depth;

		public Texture2D Normal;

		public List<BoothLight> Lights = new List<BoothLight>();

		public Booth(string name, Vector3 camPos, Vector3 camRot, float camFOV, float camFar, float camNear, Texture2D color, Texture2D depth, Texture2D normal)
		{
			Name = name;
			CamPos = camPos;
			CamRot = camRot;
			CamFOV = camFOV;
			CamFar = camFar;
			CamNear = camNear;
			Color = color;
			Depth = depth;
			Normal = normal;
		}
	}

	public string Name;

	public Camera Cam;
}
