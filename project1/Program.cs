/*
 * Created by SharpDevelop.
 * User: Monokli
 * Date: 2018.02.06.
 * Time: 21:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project1
{
	public enum parttypes {chassis, hw_gun, hw_laser, hw_mobility, hw_launcher};
	 
	 //hardware ends here
	 
	//Program starts here 
	class Program
	{
		public static int Main(string[] args)
		{
			// TODO: Implement Functionality Here
			robot r = new robot();
			r.alpha();
			for(float i=0.4f;i<14f;i=i+0.8f)
			{
				Console.WriteLine("elapsed time: {0} seconds",i);
				Console.WriteLine("Heat: {0}",r.getheat());
				r.update(0.8f);
				r.alpha();
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			return 0;
		}
	}
}