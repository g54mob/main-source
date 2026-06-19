using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BehaviourTagsAuthoring : MonoBehaviour
{
	public List<ObjectCategoryTag> wantsToAttackTags;

	public List<ObjectCategoryTag> cantAttackTags;

	public List<ObjectCategoryTag> eatsTags;
}
