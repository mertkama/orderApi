# .Net Core 5 ile WebApi

Bu API .Net Core 5 ile geliştiriliyor.

İlk olarak proje klasörü içerisinde alt kısımdaki komut çalıştırılarak bir 'WebApi' isminde bir Api oluşturmak için:

    dotnet new webapi -n WebApi 

Sonrasında hala proje klasörünün içerisindeyken şu komut ile 'OrderSln' adında bir **sln** dosyası oluşturmak için:

    dotnet new sln -n OrderSln

Artık WebApi ile OrderSln'i birleştirmemiz gerekiyor. Bunun için:

    dotnet sln add WebApi 

Api'yi çalıştırmak için (**WebApi** klasörünün içerisinde):

    dotnet watch run

# Paketler

EntityFrameworkCore **WebApi** içerisinde:

    dotnet add package Microsoft.EntityFrameworkCore 

    dotnet add package Microsoft.EntityFrameworkCore.Tools 

MySql kullanmak için **WebApi** içerisinde:

    dotnet add package Pomelo.EntityFrameworkCore.MySql 
![Ekran görüntüsü 2022-03-05 013536](https://user-images.githubusercontent.com/97520268/156851310-17949cd7-2686-4899-883f-c59491cd1a22.png)


![Ekran görüntüsü 2022-03-05 020135](https://user-images.githubusercontent.com/97520268/156853711-ccc97fb4-eb68-4541-aebe-74d619c7b8fd.png)


