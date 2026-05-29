using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.Component.Prediction
{
	public class RigidbodyPauser
	{
		private struct RigidbodyData
		{
			public Rigidbody Rigidbody;

			public Vector3 Velocity;

			public Vector3 AngularVelocity;

			public Scene SimulatedScene;

			public bool IsKinematic;

			public Transform Parent;

			public bool HasParent;

			public RigidbodyData(Rigidbody rb)
			{
				Rigidbody = null;
				Velocity = default(Vector3);
				AngularVelocity = default(Vector3);
				SimulatedScene = default(Scene);
				IsKinematic = false;
				Parent = null;
				HasParent = false;
			}

			public void Update(Rigidbody rb)
			{
			}
		}

		private struct Rigidbody2DData
		{
			public Rigidbody2D Rigidbody2d;

			public Vector2 Velocity;

			public float AngularVelocity;

			public Scene SimulatedScene;

			public bool Simulated;

			public bool IsKinematic;

			public Transform Parent;

			public bool HasParent;

			public Rigidbody2DData(Rigidbody2D rb)
			{
				Rigidbody2d = null;
				Velocity = default(Vector2);
				AngularVelocity = 0f;
				SimulatedScene = default(Scene);
				Simulated = false;
				IsKinematic = false;
				Parent = null;
				HasParent = false;
			}

			public void Update(Rigidbody2D rb)
			{
			}
		}

		private List<RigidbodyData> _rigidbodyDatas;

		private List<Rigidbody2DData> _rigidbody2dDatas;

		private static Scene _kinematicSceneCache;

		private Transform _graphicalParent;

		private Transform _graphicalObject;

		private bool _getInChildren;

		private Transform _transform;

		private RigidbodyType _rigidbodyType;

		private bool _initialized;

		public bool Paused { get; private set; }

		private static Scene _kinematicScene => default(Scene);

		public void UpdateRigidbodies()
		{
		}

		public void UpdateRigidbodies(Transform t, RigidbodyType rbType, bool getInChildren, Transform graphicalObject)
		{
		}

		public void Pause()
		{
		}

		public void Unpause()
		{
		}
	}
}
