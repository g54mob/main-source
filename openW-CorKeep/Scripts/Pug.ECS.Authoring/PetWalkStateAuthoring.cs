using Unity.Physics.Authoring;
using UnityEngine;

[RequireComponent(typeof(BehaviourTagsAuthoring))]
public class PetWalkStateAuthoring : MonoBehaviour
{
	public PhysicsShapeAuthoring belongsToShape;
}
