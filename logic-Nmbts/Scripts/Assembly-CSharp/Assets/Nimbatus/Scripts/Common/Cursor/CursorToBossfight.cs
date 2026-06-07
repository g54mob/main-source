using Assets.Nimbatus.Scripts.GalaxyMap.Boss;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Cursor
{
	public class CursorToBossfight : MonoBehaviour
	{
		public SpriteRenderer Sprite;

		public Transform Target;

		public float MaxDistance;

		public Collider[] Exclusion;

		private BossfightManager _fight;

		public void Init(BossfightManager fight)
		{
			_fight = fight;
		}

		public void Update()
		{
			if (_fight == null)
			{
				Sprite.enabled = false;
				return;
			}
			Vector3 vector = new Vector3(RuntimeGlobals.Camera.Camera.transform.position.x, RuntimeGlobals.Camera.Camera.transform.position.y, 0f);
			Vector3 vector2 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0f, 1f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z));
			Vector3 vector3 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(1f, 1f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z));
			Vector3 vector4 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z));
			Vector3 vector5 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z));
			Vector3 b = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z + 10f));
			Vector3 b2 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z + 10f));
			Vector3 b3 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z + 10f));
			Vector3 b4 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f - RuntimeGlobals.Camera.Camera.transform.position.z + 10f));
			Plane plane = new Plane(vector2, b, vector3);
			Plane plane2 = new Plane(vector3, b2, vector5);
			Plane plane3 = new Plane(vector5, b3, vector4);
			Plane plane4 = new Plane(vector4, b4, vector2);
			Vector3 vector6 = new Vector3(Target.position.x, Target.position.y, 0f);
			Vector3 direction = vector6 - vector;
			Ray ray = new Ray(vector, direction);
			float enter;
			plane.Raycast(ray, out enter);
			float enter2;
			plane2.Raycast(ray, out enter2);
			float enter3;
			plane3.Raycast(ray, out enter3);
			float enter4;
			plane4.Raycast(ray, out enter4);
			if (Mathf.FloorToInt(enter) <= 0)
			{
				enter = float.PositiveInfinity;
			}
			if (Mathf.FloorToInt(enter2) <= 0)
			{
				enter2 = float.PositiveInfinity;
			}
			if (Mathf.FloorToInt(enter3) <= 0)
			{
				enter3 = float.PositiveInfinity;
			}
			if (Mathf.FloorToInt(enter4) <= 0)
			{
				enter4 = float.PositiveInfinity;
			}
			float num = Mathf.Min(enter, enter2, enter3, enter4);
			Vector3 position = ((direction.magnitude < num) ? vector6 : ray.GetPoint(num));
			position -= direction.normalized * (1f + (Mathf.Sin(Time.time * 10f) + 1f) * 0.5f * 2f);
			Sprite.transform.position = position;
			Sprite.transform.position = new Vector3(position.x, position.y, RuntimeGlobals.Camera.Camera.transform.position.z + 2f);
			Sprite.transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(direction.y, direction.x) * 57.29578f);
			Vector2 vector7 = RuntimeGlobals.Camera.transform.position - vector6;
			Vector3 position2 = Sprite.transform.position;
			position2.z = 0f;
			bool flag = false;
			Collider[] exclusion = Exclusion;
			for (int i = 0; i < exclusion.Length; i++)
			{
				if (exclusion[i].bounds.Contains(position2))
				{
					flag = true;
					break;
				}
			}
			Sprite.enabled = vector7.magnitude > MaxDistance && !flag;
		}
	}
}
