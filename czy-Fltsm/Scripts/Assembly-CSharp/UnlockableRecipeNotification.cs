using UnityEngine;

public class UnlockableRecipeNotification : INotificationObjectOfInterest
{
	public GameObject GameObjectOfInterest { get; private set; }

	public ObjectType ObjectOfInterestType => ObjectType.Buildable;

	public ProductionRecipeProperties RecipeProperties { get; private set; }

	public UnlockableRecipeNotification(GameObject objectOfInterest, ProductionRecipeProperties recipeProperties)
	{
		GameObjectOfInterest = objectOfInterest;
		RecipeProperties = recipeProperties;
	}

	public string NotificationReplaceVariables(string message)
	{
		return TextManager.ReplaceVariables(message, RecipeProperties);
	}

	public void NotificationLeftClick()
	{
		if (GameObjectOfInterest != null)
		{
			CameraController.Instance.Lock(GameObjectOfInterest);
		}
	}

	public bool IsMatch(INotificationObjectOfInterest objectOfInterest)
	{
		if (objectOfInterest.ObjectOfInterestType == ObjectType.Buildable && objectOfInterest is UnlockableRecipeNotification unlockableRecipeNotification)
		{
			return RecipeProperties == unlockableRecipeNotification.RecipeProperties;
		}
		return false;
	}
}
