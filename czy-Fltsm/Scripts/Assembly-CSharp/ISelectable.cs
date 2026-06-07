using UnityEngine;

public interface ISelectable
{
	ObjectType ObjectType { get; }

	GameObject RelatedGameObject { get; }
}
