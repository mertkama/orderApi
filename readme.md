# .Net Core 5 ile WebApi

Bu API .Net Core 5 ile geliştiriliyor.

İlk olarak proje klasörü içerisinde alt kısımdaki komut çalıştırılarak bir 'WebApi' isminde bir Api oluşturmak için:

    dotnet new webapi -n WebApi 

Sonrasında hala proje klasörünün içerisindeyken şu komut ile 'SupplierSln' adında bir **sln** dosyası oluşturmak için:

    dotnet new sln -n SupplierSln

Artık WebApi ile SupplierSln'i birleştirmemiz gerekiyor. Bunun için:

    dotnet sln add WebApi 

Api'yi çalıştırmak için (**WebApi** klasörünün içerisinde):

    dotnet watch run

# Paketler

EntityFrameworkCore **WebApi** içerisinde:

    dotnet add package Microsoft.EntityFrameworkCore 

    dotnet add package Microsoft.EntityFrameworkCore.Tools 

MySql kullanmak için **WebApi** içerisinde:

    dotnet add package Pomelo.EntityFrameworkCore.MySql 


