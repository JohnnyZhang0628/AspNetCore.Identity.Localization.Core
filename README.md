# AspNetCore.Identity.Localization [![GitHub license](https://img.shields.io/github/license/JohnnyZhang0628/AspNetCore.Identity.Localization.Core)](https://github.com/JohnnyZhang0628/AspNetCore.Identity.Localization.Core/blob/main/LICENSE) [![NuGet](https://img.shields.io/nuget/v/AspNetCore.Identity.Localization.Core)](https://www.nuget.org/packages/AspNetCore.Identity.Localization.Core/) ![downloads](https://img.shields.io/nuget/dt/AspNetCore.Identity.Localization.Core)

Microsoft.AspNetCore.Identity localization.Support zh-CN,en-US,de-DE,es-ES,fr-FR,pl-PL,pt-PT,ru-RU,tr-TR,uk-UA language

Microsoft.AspNetCore.Identity是支持多种语言的语言包。

## Install
`Install-Package AspNetCore.Identity.Localization.Core`

## Use
1、`using AspNetCore.Identity.Localization.Core;`

2、update `ConfigureServices` method in  `Startup.cs` file.
```diff
services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("Identity")));

services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
- .AddIdentityErrorDescriber();

- services.AddIdentityLocalization();

services.AddControllers();

```
3、update `ConfigureServices` method in  `Startup.cs` file.
```diff
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

- // support language list.The web site default language is cultures[0]
- var cultures = Configuration.GetSection("Cultures").Value.Split(",");
- app.UseIdentityLocalization(cultures);

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
   endpoints.MapControllers();
});

```

4、update  `appsettings.json` file.

`  "Cultures": "zh-CN,en-US,de-DE,es-ES,fr-FR,pl-PL,pt-PT,ru-RU,tr-TR,uk-UA"`
## test
1.`git clone https://github.com/JohnnyZhang0628/AspNetCore.Identity.Localization.Core.git`

2. open WebIdentity.sln

3. open [http://localhost:54176/api/identity?culture=zh-cn](http://localhost:54176/api/identity?culture=zh-cn) in browser.

`culture` parameter in `zh-CN,en-US,de-DE,es-ES,fr-FR,pl-PL,pt-PT,ru-RU,tr-TR,uk-UA`

## add other language 
1.copy SharedResource.zh-CN.resx and rename SharedResource.other-other.resx.

2.add 'other-other' in `Cultures` value.

3.open [http://localhost:54176/api/identity?culture=other-other](http://localhost:54176/api/identity?culture=other-other) in browser.



