using System;
using System.Collections.Generic;
using System.Dynamic;

namespace VisitorPattern
{
	public interface IComponent
	{
		void Accept(IVisitor visitor);
	}

	public class ComponentA : IComponent
	{
		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}

		public string ExclusiveOfA()
		{
			return "A";
		}
	}

	public class ComponentB : IComponent
	{
		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}

		public string ExclusiveOfB()
		{
			return "B";
		}
	}

	public interface IVisitor
	{
		void Visit(ComponentA componentA);
		void Visit(ComponentB componentB);
	}

	public class ConcreteVisitor1 : IVisitor
	{
		public void Visit(ComponentA componentA)
		{
			Console.WriteLine($"{nameof(componentA.ExclusiveOfA)}: {componentA.ExclusiveOfA()} -- {nameof(ConcreteVisitor1)}");
		}

		public void Visit(ComponentB componentB)
		{
			Console.WriteLine($"{nameof(componentB.ExclusiveOfB)}: {componentB.ExclusiveOfB()} -- {nameof(ConcreteVisitor1)}");
		}
	}

	public class ConcreteVisitor2 : IVisitor
	{
		public void Visit(ComponentA componentA)
		{
			Console.WriteLine($"{nameof(componentA.ExclusiveOfA)}: {componentA.ExclusiveOfA()} -- {nameof(ConcreteVisitor2)}");
		}

		public void Visit(ComponentB componentB)
		{
			Console.WriteLine($"{nameof(componentB.ExclusiveOfB)}: {componentB.ExclusiveOfB()} -- {nameof(ConcreteVisitor2)}");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var componentList = new List<IComponent>
			{
				new ComponentA(),
				new ComponentB()
			};

			var visitor1 = new ConcreteVisitor1();
			foreach (var component in componentList)
			{
				component.Accept(visitor1);
			}

			var visitor2 = new ConcreteVisitor2();
			foreach (var component in componentList)
			{
				component.Accept(visitor2);
			}
		}
	}
}
