using UnityEngine;

public class FeedProperties : ItemProperties
{
	[Header("Feed Properties")]
	[Range(1f, 10f)]
	[SerializeField]
	private int _portions = 1;

	public int Portions => _portions;
}
