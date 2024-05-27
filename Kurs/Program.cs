using Kurs.Service.Services.Implementations;
using Kurs.Service.Services.Interfaces;

static async Task Main(string[] args)
{
	IMenuService menu = new MenuService();

	await menu.ShowMenuAsync();
}

