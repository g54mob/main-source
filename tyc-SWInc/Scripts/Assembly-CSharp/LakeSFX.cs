using UnityEngine;

public class LakeSFX : MonoBehaviour
{
	public float FadeSpeed = 2f;

	public AudioSource Source;

	private void Update()
	{
		if (GameSettings.GameSpeed == 0f)
		{
			if (Source.isPlaying)
			{
				Source.Pause();
			}
		}
		else if (!Source.isPlaying)
		{
			Source.Play();
		}
		Lake lake = null;
		bool flag = false;
		Ray ray = CameraScript.Instance.SSAScript.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
		float enter;
		new Plane(Vector3.up, Vector3.zero).Raycast(ray, out enter);
		Vector2 vector = ray.GetPoint(enter).FlattenVector3();
		for (int i = 0; i < RoadManager.Instance.Landmarks.Count; i++)
		{
			Lake lake2 = RoadManager.Instance.Landmarks[i] as Lake;
			if (lake2 != null && lake2.LakeArea.Expand(16f, 16f).Contains(vector))
			{
				if (lake != null)
				{
					flag = true;
					break;
				}
				lake = lake2;
			}
		}
		if (!flag && lake != null && Utilities.IsInside(vector, lake.LakeBounds))
		{
			flag = true;
		}
		if (flag)
		{
			base.transform.position = CameraScript.Instance.LastListenerPos.ReplaceY(0f);
			Source.volume = Mathf.Lerp(Source.volume, 1f, Time.deltaTime * FadeSpeed);
		}
		else if (lake != null)
		{
			Vector2[] lakeBounds = lake.LakeBounds;
			float num = float.MaxValue;
			Vector2 v = new Vector2(5000f, 5000f);
			for (int j = 0; j < lakeBounds.Length; j++)
			{
				Vector2 a = lakeBounds[j];
				Vector2 b = lakeBounds[(j + 1) % lakeBounds.Length];
				Vector2 vector2 = Utilities.ProjectToLineEndlessClamped(vector, a, b);
				float sqrMagnitude = (vector2 - vector).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					v = vector2;
					num = sqrMagnitude;
				}
			}
			base.transform.position = v.ToVector3(0f);
			Source.volume = Mathf.Lerp(Source.volume, 1f, Time.deltaTime * FadeSpeed);
		}
		else
		{
			Source.volume = Mathf.Lerp(Source.volume, 0f, Time.deltaTime * FadeSpeed);
		}
	}
}
