using System.Collections.Generic;
using UnityEngine;

public class ScreenMarkerManager : MonoBehaviour
{
	public enum MarkerMode
	{
		Direction = 0,
		ClampedPos = 1
	}

	private class ComparePositionX : IComparer<ScreenMarker>
	{
		public int Compare(ScreenMarker a, ScreenMarker b)
		{
			if (!object.Equals(a.UnclampedScreenPos.x, b.UnclampedScreenPos.x))
			{
				return Comparer<float>.Default.Compare(a.UnclampedScreenPos.x, b.UnclampedScreenPos.x);
			}
			return Comparer<float>.Default.Compare(a.MyRandomVal - (float)a.Number, b.MyRandomVal - (float)b.Number);
		}
	}

	private class ComparePositionY : IComparer<ScreenMarker>
	{
		public int Compare(ScreenMarker a, ScreenMarker b)
		{
			if (!object.Equals(a.UnclampedScreenPos.y, b.UnclampedScreenPos.y))
			{
				return Comparer<float>.Default.Compare(a.UnclampedScreenPos.y, b.UnclampedScreenPos.y);
			}
			return Comparer<float>.Default.Compare(a.MyRandomVal - (float)a.Number, b.MyRandomVal - (float)b.Number);
		}
	}

	public static ScreenMarkerManager instance;

	private List<ScreenMarker> screenMarkersActive = new List<ScreenMarker>();

	private List<ScreenMarker> screenMarkersToShow = new List<ScreenMarker>();

	private Dictionary<ScreenMarker, int> screenMarkerInGroup = new Dictionary<ScreenMarker, int>();

	private List<List<ScreenMarker>> screenMarkerGroups = new List<List<ScreenMarker>>();

	private Camera cam;

	private float ratio;

	private float clampY;

	private float clampX;

	private int frame;

	[SerializeField]
	private MarkerMode markerMode;

	private float FIXED_CANVAS_HEIGHT => ScreenMarkerCanvasHelper.instance.Height;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		cam = Camera.main;
		UpdateCam();
	}

	private void UpdateCam()
	{
		ratio = cam.pixelRect.width / cam.pixelRect.height;
		clampY = FIXED_CANVAS_HEIGHT / 2f;
		clampX = FIXED_CANVAS_HEIGHT / 2f * ratio;
	}

	public void RegisterScreenMarker(ScreenMarker _sm)
	{
		if (!screenMarkersActive.Contains(_sm))
		{
			screenMarkersActive.Add(_sm);
		}
	}

	public void UnregisterScreenMarker(ScreenMarker _sm)
	{
		if (screenMarkersActive.Contains(_sm))
		{
			screenMarkersActive.Remove(_sm);
		}
	}

	private void Update()
	{
		frame++;
		if (frame < 2)
		{
			return;
		}
		UpdateCam();
		screenMarkersToShow.Clear();
		for (int num = screenMarkersActive.Count - 1; num >= 0; num--)
		{
			UpdateMarkerPosition(screenMarkersActive[num]);
		}
		for (int i = 0; i < screenMarkerGroups.Count; i++)
		{
			screenMarkerGroups[i].Clear();
		}
		screenMarkerInGroup.Clear();
		while (screenMarkerGroups.Count < screenMarkersToShow.Count)
		{
			screenMarkerGroups.Add(new List<ScreenMarker>());
		}
		for (int j = 0; j < screenMarkersToShow.Count; j++)
		{
			screenMarkerGroups[j].Add(screenMarkersToShow[j]);
			screenMarkerInGroup.Add(screenMarkersToShow[j], j);
		}
		bool flag = true;
		int num2 = 30;
		while (flag && num2 > 0)
		{
			num2--;
			bool flag2 = false;
			for (int k = 0; k < screenMarkersToShow.Count; k++)
			{
				ScreenMarker screenMarker = screenMarkersToShow[k];
				for (int l = k + 1; l < screenMarkersToShow.Count; l++)
				{
					ScreenMarker screenMarker2 = screenMarkersToShow[l];
					if (!CheckOverlap(screenMarker, screenMarker2))
					{
						continue;
					}
					int num3 = screenMarkerInGroup[screenMarker];
					int num4 = screenMarkerInGroup[screenMarker2];
					if (num3 != num4)
					{
						flag2 = true;
						for (int m = 0; m < screenMarkerGroups[num4].Count; m++)
						{
							ScreenMarker screenMarker3 = screenMarkerGroups[num4][m];
							screenMarkerGroups[num4].Remove(screenMarker3);
							screenMarkerGroups[num3].Add(screenMarker3);
							screenMarkerInGroup[screenMarker3] = num3;
						}
					}
				}
			}
			flag = flag2;
			if (flag2)
			{
				for (int n = 0; n < screenMarkerGroups.Count; n++)
				{
					FormatGroup(screenMarkerGroups[n]);
				}
			}
		}
		for (int num5 = 0; num5 < screenMarkersToShow.Count; num5++)
		{
			ScreenMarker screenMarker4 = screenMarkersToShow[num5];
			if (screenMarker4.rotateTowardsTargetWhenOffscreen)
			{
				if (screenMarker4.OnScreen)
				{
					screenMarker4.ImageRotation = 0f;
				}
				else
				{
					screenMarker4.ImageRotation = Vector2.SignedAngle(Vector2.down, screenMarker4.UnclampedScreenPos - screenMarker4.Position);
				}
			}
		}
	}

	private bool CheckOverlap(ScreenMarker _sm1, ScreenMarker _sm2)
	{
		if (_sm1.Rect != _sm2.Rect)
		{
			return false;
		}
		if (_sm1.UnclampedScreenPos == _sm2.UnclampedScreenPos)
		{
			return true;
		}
		Rect rect = _sm1.Rect;
		Rect rect2 = _sm2.Rect;
		if (Mathf.Abs(_sm1.Position.x - _sm2.Position.x) > Mathf.Abs(rect.width + rect2.width) / 2f)
		{
			return false;
		}
		if (Mathf.Abs(_sm1.Position.y - _sm2.Position.y) > Mathf.Abs(rect.height + rect2.height) / 2f)
		{
			return false;
		}
		return true;
	}

	private void FormatGroup(List<ScreenMarker> _group)
	{
		if (_group.Count <= 0)
		{
			return;
		}
		Vector2 zero = Vector2.zero;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		for (int i = 0; i < _group.Count; i++)
		{
			zero += _group[i].ClampedScreenPos;
			num3 += _group[i].Rect.width;
			num4 += _group[i].Rect.height;
			if (i > 0)
			{
				num -= _group[i].Rect.width / 2f;
				num2 -= _group[i].Rect.height / 2f;
			}
		}
		zero /= (float)_group.Count;
		if (Mathf.Abs(zero.x / clampX) < Mathf.Abs(zero.y / clampY))
		{
			zero = new Vector2(Mathf.Clamp(zero.x, 0f - clampX + num3 / 2f, clampX - num3 / 2f), zero.y);
			_group.Sort(new ComparePositionX());
			for (int j = 0; j < _group.Count; j++)
			{
				_group[j].Position = zero + Vector2.right * (_group[j].Rect.width * (float)j + num);
			}
		}
		else
		{
			zero = new Vector2(zero.x, Mathf.Clamp(zero.y, 0f - clampY + num4 / 2f, clampY - num4 / 2f));
			_group.Sort(new ComparePositionY());
			for (int k = 0; k < _group.Count; k++)
			{
				_group[k].Position = zero + Vector2.down * (_group[k].Rect.height * (float)k + num2);
			}
		}
	}

	public void UpdateMarkerPosition(ScreenMarker _sm)
	{
		if (_sm == null)
		{
			return;
		}
		float num = cam.pixelRect.height / FIXED_CANVAS_HEIGHT;
		Vector3 vector = cam.WorldToScreenPoint(_sm.transform.position);
		Vector2 vector2 = (_sm.UnclampedScreenPos = new Vector2(vector.x - cam.pixelRect.width * 0.5f, vector.y - cam.pixelRect.height * 0.5f) / num);
		bool flag = true;
		if (Mathf.Abs(vector2.y) > clampY - _sm.checkOnScreenRect.height / 2f)
		{
			flag = false;
		}
		else if (Mathf.Abs(vector2.x) > clampX - _sm.checkOnScreenRect.width / 2f)
		{
			flag = false;
		}
		_sm.OnScreen = flag;
		if ((flag && _sm.showWhenOnScreen) || (!flag && _sm.showWhenOffScreen))
		{
			screenMarkersToShow.Add(_sm);
			_sm.Show(_show: true);
			if (markerMode == MarkerMode.Direction)
			{
				float num2 = (clampX - _sm.Rect.width / 2f) / Mathf.Abs(vector2.x);
				float num3 = (clampY - _sm.Rect.height / 2f) / Mathf.Abs(vector2.y);
				float num4 = Mathf.Min(num2, num3, 1f);
				vector2 = new Vector2(vector2.x, vector2.y) * num4;
			}
			else
			{
				Rect rect = _sm.Rect;
				vector2 = new Vector2(Mathf.Clamp(vector2.x, 0f - clampX + rect.width / 2f, clampX - rect.width / 2f), Mathf.Clamp(vector2.y, 0f - clampY + rect.height / 2f, clampY - rect.height / 2f));
			}
			_sm.Position = vector2;
			_sm.ClampedScreenPos = vector2;
		}
		else
		{
			_sm.Show(_show: false);
		}
	}
}
