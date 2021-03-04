import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';

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
	  this.http.get<Results[]>(this.baseUrl + 'api/result/finished').subscribe(result => {
      this.results = result;
    }, error => console.error(error));
  }
}

interface Results {
  MatchId: string;
  UserId: string;
  Number: string;
}