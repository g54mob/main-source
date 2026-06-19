public abstract class IngameButtonHint : UIelement
{
	public virtual bool isButtonActive => true;

	public abstract void UpdateVisuals();
}
