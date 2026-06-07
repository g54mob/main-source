public class ProductionRecipeEvent : GameEvent
{
	private static ProductionRecipeEvent _instance;

	public ProductionRecipeProperties RecipeProperties { get; private set; }

	public int RecipePriority { get; private set; }

	public static void Dispatch(GameEventType type, ProductionRecipeProperties properties)
	{
		if (_instance == null)
		{
			_instance = new ProductionRecipeEvent();
		}
		_instance.SetData(type, properties);
		_instance.Dispatch();
	}

	public static void DispatchPriorityChange(int recipePriority)
	{
		if (_instance == null)
		{
			_instance = new ProductionRecipeEvent();
		}
		_instance.SetData(GameEventType.ProducerPriorityChange, null, recipePriority);
		_instance.Dispatch();
	}

	private ProductionRecipeEvent()
		: base(GameEventType.None)
	{
	}

	private void SetData(GameEventType type, ProductionRecipeProperties properties, int recipePriority = 0)
	{
		base.EventType = type;
		RecipeProperties = properties;
		RecipePriority = recipePriority;
	}
}
