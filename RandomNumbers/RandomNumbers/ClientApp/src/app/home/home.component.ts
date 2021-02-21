import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public results: Results[];
  private http : HttpClient;
  private baseUrl : string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
	  this.http = http;
	  this.baseUrl = baseUrl;
  };

  public getAll() {
	  this.http.get<Cities[]>(this.baseUrl + 'api/result/finished').subscribe(result => {
      this.results = result;
	  console.log(this.cities);
    }, error => console.error(error));
  }
}

interface Results {
  MatchId: string;
  UserId: string;
  Number: string;
}