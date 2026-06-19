namespace PugTilemap.Workshop
{
	public class Tool
	{
		protected Workshop ed;

		public string name;

		public Tool(Workshop ed, string name)
		{
			this.ed = ed;
			this.name = name;
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void OnMouseMove()
		{
		}

		public virtual void OnMouseDown()
		{
		}

		public virtual void OnMouseDrag()
		{
		}

		public virtual void OnMouseUp()
		{
		}

		public virtual void Draw()
		{
		}
	}
}
