using UnityEngine;

public interface IRecyclable
{
	RecyclableType RecyclableId { get; }

	GameObject GameObject { get; }
}
