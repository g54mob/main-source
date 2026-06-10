using NSEipix.Base;

public interface ISettingsData<TM> where TM : Model
{
	TM GetData<TModel>() where TModel : Model;
}
