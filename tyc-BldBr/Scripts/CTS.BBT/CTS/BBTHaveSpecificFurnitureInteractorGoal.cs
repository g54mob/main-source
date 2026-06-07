using System;

namespace CTS
{
	[Serializable]
	public class BBTHaveSpecificFurnitureInteractorGoal<T> : BBTGoal<HaveSpecificFurnitureInteractorGoal<T>> where T : class, IInteractiveFurniture
	{
	}
}
