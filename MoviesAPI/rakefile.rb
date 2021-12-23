desc "Add Migraion"
task :'add-migration' do
    ARGV.each { |a| task a.to_sym do ; end }  
    puts ARGV[1]
    sh "dotnet-ef migrations add " + ARGV[1] + " --project MyProject.Data/MyProject.Data.csproj --startup-project MyProject.Web/MyProject.Web.csproj "
end

desc "Remove Migraion"
task :'remove-migration' do
    ARGV.each { |a| task a.to_sym do ; end }  
    puts ARGV[1]
    sh "dotnet--ef migrations remove --project MyProject.Data/MyProject.Data.csproj --startup-project MyProject.Web/MyProject.Web.csproj"
end

desc "Update Database"
task :'update-database' do
    ARGV.each { |a| task a.to_sym do ; end }  
    puts ARGV[1]
    sh "dotnet--ef database update --project MyProject.Data/MyProject.Data.csproj --startup-project MyProject.Web/MyProject.Web.csproj"
end