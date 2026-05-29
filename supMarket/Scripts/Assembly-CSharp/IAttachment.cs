using UnityEngine;

public interface IAttachment
{
	uint Id { get; }

	GameObject gameObject { get; }

	Transform transform { get; }
}
