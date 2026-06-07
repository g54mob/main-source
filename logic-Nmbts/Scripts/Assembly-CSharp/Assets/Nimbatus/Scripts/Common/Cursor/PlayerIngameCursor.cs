using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Cursor
{
	public class PlayerIngameCursor : MonoBehaviour
	{
		public SpriteRenderer Sprite;

		public void Update()
		{
			Vector3 vector = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0.5f, 0f, 1.1f));
			Vector3 normalized = new Vector3(vector.x, vector.y, 0f).normalized;
			base.transform.position = vector + normalized * ((Mathf.Sin(Time.time * 6.5f) + 1f) / 2f) * 5f;
			base.transform.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(base.transform.position.y, base.transform.position.x) * 57.29578f + 180f);
			float magnitude = new Vector3(RuntimeGlobals.Camera.Camera.transform.position.x, RuntimeGlobals.Camera.Camera.transform.position.y, 0f).magnitude;
			Sprite.enabled = magnitude > (float)WorldController.TerrainSettings.PlanetSize * 2f;
		}
	}
}
