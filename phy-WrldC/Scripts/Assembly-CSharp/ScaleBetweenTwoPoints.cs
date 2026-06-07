using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScaleBetweenTwoPoints : MonoBehaviour
{
	[SerializeField]
	private Transform startLocation;

	[SerializeField]
	private Transform endLocation;

	[SerializeField]
	private Vector3 startPosition;

	[SerializeField]
	private Vector3 endPosition;

	[SerializeField]
	private bool shouldRunInRealTime;

	private List<SpriteAutoTileScaler> spriteAutoTileScalers;

	public Transform StartLocation
	{
		get
		{
			return startLocation;
		}
		set
		{
			startLocation = value;
		}
	}

	public Transform EndLocation
	{
		get
		{
			return endLocation;
		}
		set
		{
			endLocation = value;
		}
	}

	public Vector3 StartPosition
	{
		get
		{
			if (startLocation != null)
			{
				return startLocation.position;
			}
			return startPosition;
		}
		set
		{
			startPosition = value;
		}
	}

	public Vector3 EndPosition
	{
		get
		{
			if (endLocation != null)
			{
				return endLocation.position;
			}
			return endPosition;
		}
		set
		{
			endPosition = value;
		}
	}

	public float Distance { get; private set; }

	private void Awake()
	{
		spriteAutoTileScalers = new List<SpriteAutoTileScaler>();
		base.transform.GetComponentsInChildren(includeInactive: true, spriteAutoTileScalers);
	}

	private void Update()
	{
		if (shouldRunInRealTime)
		{
			UpdateScale();
		}
	}

	public void UpdateScale()
	{
		if (!(StartPosition == EndPosition))
		{
			Distance = Vector3.Distance(StartPosition, EndPosition);
			base.transform.localScale = new Vector3(Distance, base.transform.localScale.y, base.transform.localScale.z);
			base.transform.position = StartPosition;
			base.transform.LookAt(EndPosition);
			base.transform.Translate(new Vector3(0f, 0f, Distance / 2f), Space.Self);
			base.transform.Rotate(new Vector3(0f, 90f, 0f));
			spriteAutoTileScalers.ForEach(delegate(SpriteAutoTileScaler autoScalers)
			{
				autoScalers.UpdateSpriteRenderer();
			});
		}
	}
}
