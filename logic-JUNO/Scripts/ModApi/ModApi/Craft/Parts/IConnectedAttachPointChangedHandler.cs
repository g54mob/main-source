namespace ModApi.Craft.Parts
{
	public interface IConnectedAttachPointChangedHandler
	{
		void OnAttachPointRadiusChanged(AttachPoint connectionAttachPoint, AttachPoint otherAttachPoint);
	}
}
