using System.Collections.Generic;
using UnityEngine;

public class ConferenceWayPoint : MonoBehaviour
{
	public bool Entry;

	public bool Stage;

	public string BoothScene;

	public ConferenceController.BoothSize BoothSize;

	public float BoothRotation;

	public float BoothScore;

	public float ConnectionRange = 180f;

	public Vector2 StageArea = Vector2.one;

	public List<ConferenceWayPoint> Connections = new List<ConferenceWayPoint>();

	public bool Booth
	{
		get
		{
			return !string.IsNullOrWhiteSpace(BoothScene);
		}
	}
}
