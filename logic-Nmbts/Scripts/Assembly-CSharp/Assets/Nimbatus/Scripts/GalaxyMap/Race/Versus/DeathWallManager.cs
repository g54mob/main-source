using Assets.Nimbatus.Scripts.GalaxyMap.Race.Tracker;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Versus
{
	public class DeathWallManager : MonoBehaviour
	{
		public float Delay;

		public float Speed = 50f;

		public float MaxDistance = 200f;

		public Material DeathWallMaterial;

		public LayerMask KillLayers;

		public string DeathWallSoundLoop;

		private bool _initialised;

		private float _timer;

		private RaceTrack _track;

		private TrackerManager _trackerL;

		private TrackerManager _trackerR;

		private DeathWall _wallL;

		private DeathWall _wallR;

		public void Init(RaceTrack track, TrackerManager trackerL, TrackerManager trackerR, RaceSpline splineL, RaceSpline splineR)
		{
			_track = track;
			_trackerL = trackerL;
			_trackerR = trackerR;
			_wallL = AddDeathWall(splineL);
			_wallR = AddDeathWall(splineR);
			_wallL.PositionAlongSpline = Mathf.Clamp(_trackerL.GetDroneBrainPosition() - MaxDistance, 0f, float.PositiveInfinity);
			_wallR.PositionAlongSpline = Mathf.Clamp(_trackerR.GetDroneBrainPosition() - MaxDistance, 0f, float.PositiveInfinity);
			if (!string.IsNullOrEmpty(DeathWallSoundLoop))
			{
				AudioController.Play(DeathWallSoundLoop, _wallL.transform);
			}
			_initialised = true;
		}

		public void Update()
		{
			if (!_initialised)
			{
				return;
			}
			for (int i = 0; i < 2; i++)
			{
				DeathWall deathWall = ((i == 0) ? _wallL : _wallR);
				if (_timer < Delay)
				{
					_timer += Time.deltaTime;
				}
				else
				{
					deathWall.PositionAlongSpline += Speed * Time.deltaTime;
					float lastPosition = _trackerL.GetLastPosition();
					float lastPosition2 = _trackerR.GetLastPosition();
					float num = Mathf.Min(lastPosition, lastPosition2);
					if (num < float.MaxValue && deathWall.PositionAlongSpline < num - MaxDistance)
					{
						deathWall.PositionAlongSpline = num - MaxDistance;
					}
					if (deathWall.PositionAlongSpline > deathWall.MasterSpline.Length)
					{
						if (deathWall.MasterSpline.ForkTargetSpline != null)
						{
							Vector3 reference = deathWall.MasterSpline.GetLocationAlongSplineAtDistance(deathWall.MasterSpline.Length) + _track.transform.position;
							deathWall.MasterSpline = deathWall.MasterSpline.ForkTargetSpline;
							deathWall.PositionAlongSpline = GetStartPosition(deathWall.MasterSpline, reference);
						}
						else if (deathWall.MasterSpline.Loop)
						{
							deathWall.PositionAlongSpline -= deathWall.MasterSpline.Length;
						}
						else if (!deathWall.MasterSpline.Loop)
						{
							deathWall.PositionAlongSpline = deathWall.MasterSpline.Length;
						}
					}
				}
				Vector3 vector = deathWall.MasterSpline.GetLocationAlongSplineAtDistance(deathWall.PositionAlongSpline) + _track.transform.position;
				Vector3 tangentAlongSplineAtDistance = deathWall.MasterSpline.GetTangentAlongSplineAtDistance(deathWall.PositionAlongSpline);
				Vector3 vector2 = Vector3.Cross(tangentAlongSplineAtDistance, Vector3.back).normalized * (_track.Scale / 2f) * deathWall.MasterSpline.GetWidthModifierAtDistance(deathWall.PositionAlongSpline);
				vector -= vector2.normalized * deathWall.MasterSpline.GetOffsetAtDistance(deathWall.PositionAlongSpline) * (_track.Scale / (_track.Scale / _track.KerbScale));
				Vector3 vector3 = vector + vector2;
				Vector3 vector4 = vector - vector2;
				deathWall.transform.position = vector;
				deathWall.transform.rotation = CubicBezierCurve.GetRotationFromTangent(tangentAlongSplineAtDistance) * Quaternion.Euler(-90f, 0f, -90f);
				deathWall.Collider.size = new Vector3(1f, (vector3 - vector4).magnitude, 10f);
				deathWall.LineRenderer.SetPosition(0, vector3);
				deathWall.LineRenderer.SetPosition(1, vector4);
			}
		}

		private DeathWall AddDeathWall(RaceSpline spline)
		{
			DeathWall deathWall = new GameObject("DeathWall", typeof(BoxCollider), typeof(LineRenderer)).AddComponent<DeathWall>();
			deathWall.gameObject.layer = 30;
			deathWall.transform.parent = base.transform;
			deathWall.MasterSpline = spline;
			deathWall.Collider = deathWall.GetComponent<BoxCollider>();
			deathWall.Collider.isTrigger = true;
			deathWall.LineRenderer = deathWall.GetComponent<LineRenderer>();
			deathWall.LineRenderer.sharedMaterial = DeathWallMaterial;
			deathWall.LineRenderer.widthMultiplier = 7f;
			deathWall.PositionAlongSpline = 0f;
			deathWall.transform.position = deathWall.MasterSpline.GetLocationAlongSplineAtDistance(deathWall.PositionAlongSpline);
			deathWall.Init(this);
			return deathWall;
		}

		private float GetStartPosition(RaceSpline spline, Vector3 reference)
		{
			float num = 0f;
			Vector3 locationAlongSplineAtDistance = spline.GetLocationAlongSplineAtDistance(num);
			float magnitude = (reference - locationAlongSplineAtDistance).magnitude;
			float num2 = magnitude;
			for (float num3 = 0f; num3 < spline.Length; num3 += 2f)
			{
				locationAlongSplineAtDistance = spline.GetLocationAlongSplineAtDistance(num3) + _track.transform.position;
				magnitude = (reference - locationAlongSplineAtDistance).magnitude;
				if (magnitude < num2)
				{
					num = num3;
					num2 = magnitude;
				}
			}
			return num;
		}
	}
}
