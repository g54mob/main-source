using System;

public abstract class BaseController<TView> where TView : IBaseView
{
	public TView view;

	public event Action<TView> OnViewChanged;

	protected BaseController(TView view)
	{
		if (view != null)
		{
			this.view = view;
			Action<string, object[]> value = ViewChangeHandler;
			view.NotifyChangeEvent += value;
			view.Controller = this;
		}
	}

	public virtual void SetView(TView newView)
	{
		if (view != null)
		{
			ref TView reference = ref view;
			Action<string, object[]> value = ViewChangeHandler;
			reference.NotifyChangeEvent -= value;
			view.Controller = null;
		}
		view = newView;
		if (view != null)
		{
			ref TView reference2 = ref view;
			Action<string, object[]> value2 = ViewChangeHandler;
			reference2.NotifyChangeEvent += value2;
			view.Controller = this;
			this.OnViewChanged?.Invoke(view);
		}
	}

	protected abstract void ViewChangeHandler(string eventName, params object[] data);
}
public abstract class BaseController<TView, TModel> : BaseController<TView> where TView : IBaseView where TModel : BaseModel
{
	public TModel model;

	public event Action<TModel, TModel> OnModelChanged;

	public event Action OnViewRebuilt;

	protected BaseController(TView view, TModel model, bool shouldSkipSync = false)
		: base(view)
	{
		if (model != null)
		{
			this.model = model;
			model.NotifyChangeEvent += ModelChangeHandler;
			if (!shouldSkipSync)
			{
				SyncViewWithModel();
			}
		}
	}

	public void SetModel(TModel newModel)
	{
		if (model != null)
		{
			model.NotifyChangeEvent -= ModelChangeHandler;
		}
		TModel arg = model;
		model = newModel;
		if (model != null)
		{
			model.NotifyChangeEvent += ModelChangeHandler;
			if (view != null)
			{
				SyncViewWithModel();
			}
			this.OnModelChanged?.Invoke(model, arg);
		}
	}

	public override void SetView(TView newView)
	{
		base.SetView(newView);
		if (view != null && model != null)
		{
			SyncViewWithModel();
		}
	}

	public void RebuildView()
	{
		if (view != null && model != null)
		{
			SyncViewWithModel();
		}
		this.OnViewRebuilt?.Invoke();
	}

	protected abstract void ModelChangeHandler(string eventName, params object[] data);

	protected abstract void SyncViewWithModel();
}
